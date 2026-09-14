using System.Collections.Generic;
using MyLeetCode.BaseModels;

namespace MyLeetCode;

public class TwoSolution : BaseSolution
{
    public override string ProblemName => "Two Sum";

    public override string ProblemDescription =>
        "You are given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\n\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\n\nYou can return the answer in any order.\n\n \n\nExample 1:\n\nInput: nums = [2,7,11,15], target = 9\nOutput: [0,1]\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\nExample 2:\n\nInput: nums = [3,2,4], target = 6\nOutput: [1,2]\nExample 3:\n\nInput: nums = [3,3], target = 6\nOutput: [0,1]\n \n\nConstraints:\n\n2 <= nums.length <= 104\n-109 <= nums[i] <= 109\n-109 <= target <= 109\nOnly one valid answer exists.";

    public override string ProblemUrl => "https://leetcode.com/problems/two-sum";
    public override Level ProblemLevel => Level.Easy;

    public override SpaceComplexity SpaceComplexity => SpaceComplexity.LinearOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>(nums.Length);
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (dict.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            dict.TryAdd(nums[i], i);
        }

        return [0, 0];
    }

    /// <summary>
    /// SpaceComplexity: O(1)
    /// TimeComplexity: O(n^2)
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum_v1(int[] nums, int target)
    {
        var len = nums.Length;
        for (var i = 0; i < len; i++)
        {
            for (var j = i + 1; j < len; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [0, 0];
    }
}