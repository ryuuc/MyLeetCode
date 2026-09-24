using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class ContainerWithMostWaterSolution : BaseSolution
{
    public override string ProblemName => "Container With Most Water";

    public override string ProblemDescription =>
        "You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).\n\nFind two lines that together with the x-axis form a container, such that the container contains the most water.\n\nReturn the maximum amount of water a container can store.\n\nNotice that you may not slant the container.\n\n \n\nExample 1:\n\n\nInput: height = [1,8,6,2,5,4,8,3,7]\nOutput: 49\nExplanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.\nExample 2:\n\nInput: height = [1,1]\nOutput: 1\n \n\nConstraints:\n\nn == height.length\n2 <= n <= 105\n0 <= height[i] <= 104";

    public override string ProblemUrl => "https://leetcode.com/problems/container-with-most-water/description/";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1, maxArea = 0;
        while (left<right)
        {
            var area = (right - left) * (height[left] > height[right] ? height[right] : height[left]);
            if (area > maxArea) maxArea = area;

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return  maxArea;
    }

    /// <summary>
    /// O(n^2)
    /// O(1)
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxArea_v1(int[] height)
    {
        var n = height.Length;
        if (n == 2) return height[0] >= height[1] ? height[1] : height[0];
        int maxArea = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var area = (j - i) * (height[i] >= height[j] ? height[j] : height[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }

        return  maxArea;
    }
}