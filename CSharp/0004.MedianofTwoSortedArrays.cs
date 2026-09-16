using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class MedianOfTwoSortedArraysSolution : BaseSolution
{
    public override string ProblemName => "Median of Two Sorted Arrays";

    public override string ProblemDescription =>
        "Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.\n\nThe overall run time complexity should be O(log (m+n)).\n\n \n\nExample 1:\n\nInput: nums1 = [1,3], nums2 = [2]\nOutput: 2.00000\nExplanation: merged array = [1,2,3] and median is 2.\nExample 2:\n\nInput: nums1 = [1,2], nums2 = [3,4]\nOutput: 2.50000\nExplanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.\n \n\nConstraints:\n\nnums1.length == m\nnums2.length == n\n0 <= m <= 1000\n0 <= n <= 1000\n1 <= m + n <= 2000\n-106 <= nums1[i], nums2[i] <= 106";

    public override string ProblemUrl => "https://leetcode.com/problems/median-of-two-sorted-arrays/";
    public override Level ProblemLevel => Level.Hard;
    public override SpaceComplexity SpaceComplexity { get; }
    public override TimeComplexity TimeComplexity { get; }

    /// <summary>
    ///TimeComplexity: O(m*n)
    ///SpaceComplexity: O(m+n) 
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays_v1(int[] nums1, int[] nums2)
    {
        int length1 = nums1.Length, length2 = nums2.Length;
        var length3 = length1 + length2;
        var mergedArray = new int[length3];
        if (length1 < length2)
        {
            length1 = length2;
            length2 = length3 - length1;

            for (var i = 0; i < length1; i++)
            {
                mergedArray[i] = nums2[i];
            }

            for (var i = 0; i < length2; i++)
            {
                mergedArray[i + length1] = nums1[i];
            }
        }
        else
        {
            for (var i = 0; i < length1; i++)
            {
                mergedArray[i] = nums1[i];
            }

            for (var i = 0; i < length2; i++)
            {
                mergedArray[i + length1] = nums2[i];
            }
        }


        for (var i = length1; i < length3; i++)
        {
            int bas = mergedArray[i], j = i - 1;
            while (j >= 0 && mergedArray[j] > bas)
            {
                mergedArray[j + 1] = mergedArray[j];
                j--;
            }

            mergedArray[j + 1] = bas;
        }

        var isOdd = length3 % 2 != 0;
        var middle = length3 / 2;
        return isOdd ? mergedArray[middle] : (mergedArray[middle - 1] + mergedArray[middle]) / 2.0;
    }
}