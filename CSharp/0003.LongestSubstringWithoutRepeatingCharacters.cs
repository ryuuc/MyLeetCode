using System.Collections.Generic;
using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class LongestSubstringWithoutRepeatingCharactersSolution : BaseSolution
{
    public override string ProblemName => "Longest Substring Without Repeating Characters";

    public override string ProblemDescription =>
        "Given a string s, find the length of the longest substring without duplicate characters.\n\n \n\nExample 1:\n\nInput: s = \"abcabcbb\"\nOutput: 3\nExplanation: The answer is \"abc\", with the length of 3. Note that \"bca\" and \"cab\" are also correct answers.\nExample 2:\n\nInput: s = \"bbbbb\"\nOutput: 1\nExplanation: The answer is \"b\", with the length of 1.\nExample 3:\n\nInput: s = \"pwwkew\"\nOutput: 3\nExplanation: The answer is \"wke\", with the length of 3.\nNotice that the answer must be a substring, \"pwke\" is a subsequence and not a substring.\n \n\nConstraints:\n\n0 <= s.length <= 105\ns consists of English letters, digits, symbols and spaces.";

    public override string ProblemUrl => "https://leetcode.com/problems/longest-substring-without-repeating-characters";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public int LengthOfLongestSubstring(string s)
    {
        int length = s.Length, left = 0, longestSubstringLength = 0, tempLeft, tempLength;
        var map = new Dictionary<char, int>();
        for (var right = 0; right < length; right++)
        {
            var currentChar = s[right];
            if (map.TryGetValue(currentChar, out var value))
            {
                tempLeft = value + 1;
                if (tempLeft > left)
                {
                    left = tempLeft;
                }
            }

            map[currentChar] = right;

            tempLength = right - left + 1;
            if (tempLength > longestSubstringLength)
            {
                longestSubstringLength = tempLength;
            }
        }

        return longestSubstringLength;
    }
}