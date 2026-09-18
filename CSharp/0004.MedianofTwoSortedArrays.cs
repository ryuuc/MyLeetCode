using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class MedianOfTwoSortedArraysSolution : BaseSolution
{
    public override string ProblemName => "Median of Two Sorted Arrays";

    public override string ProblemDescription =>
        "Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.\n\nThe overall run time complexity should be O(log (m+n)).\n\n \n\nExample 1:\n\nInput: nums1 = [1,3], nums2 = [2]\nOutput: 2.00000\nExplanation: merged array = [1,2,3] and median is 2.\nExample 2:\n\nInput: nums1 = [1,2], nums2 = [3,4]\nOutput: 2.50000\nExplanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.\n \n\nConstraints:\n\nnums1.length == m\nnums2.length == n\n0 <= m <= 1000\n0 <= n <= 1000\n1 <= m + n <= 2000\n-106 <= nums1[i], nums2[i] <= 106";

    public override string ProblemUrl => "https://leetcode.com/problems/median-of-two-sorted-arrays/";
    public override Level ProblemLevel => Level.Hard;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LogarithmicOrder;

    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // 确保在较短的数组上做二分，降低时间复杂度至 O(log(min(m, n)))
        if (nums1.Length > nums2.Length) {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int low = 0, high = m;

        while (low <= high) {
            int i = (low + high) / 2;            // nums1 的切割点（左边选 i 个）
            int j = (m + n + 1) / 2 - i;        // nums2 的切割点（左边选 j 个）

            // 处理边界：切割线切在最左侧时用 -∞，最右侧时用 +∞
            int maxLeft1  = (i == 0) ? int.MinValue : nums1[i - 1];
            int minRight1 = (i == m) ? int.MaxValue : nums1[i];

            int maxLeft2  = (j == 0) ? int.MinValue : nums2[j - 1];
            int minRight2 = (j == n) ? int.MaxValue : nums2[j];

            // 完美的切割条件
            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {
                // 总长度为奇数：左半部的最大值即为中位数
                if ((m + n) % 2 == 1) {
                    return System.Math.Max(maxLeft1, maxLeft2);
                }
                // 总长度为偶数：(左半最大值 + 右半最小值) / 2.0
                return (System.Math.Max(maxLeft1, maxLeft2) + 
                        System.Math.Min(minRight1, minRight2)) / 2.0;
            }
            else if (maxLeft1 > minRight2) {
                // nums1 划分偏右，切割点向左调整
                high = i - 1;
            }
            else {
                // nums1 划分偏左，切割点向右调整
                low = i + 1;
            }
        }

        return 0.0;
    }

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