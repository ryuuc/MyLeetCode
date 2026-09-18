using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class LongestPalindromicSubstringSolution : BaseSolution
{
    public override string ProblemName => "Longest Palindromic Substring";

    public override string ProblemDescription =>
        "Given a string s, return the longest palindromic substring in s (A substring is a contiguous non-empty sequence of characters within a string.).\n\n \n\nExample 1:\n\nInput: s = \"babad\"\nOutput: \"bab\"\nExplanation: \"aba\" is also a valid answer.\nExample 2:\n\nInput: s = \"cbbd\"\nOutput: \"bb\"\n \n\nConstraints:\n\n1 <= s.length <= 1000\ns consist of only digits and English letters.";

    public override string ProblemUrl => "https://leetcode.com/problems/longest-palindromic-substring/";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.QuadraticOrder; //n^3

    public string LongestPalindrome(string s)
    {
        var length = s.Length;
        if (length == 1) return s;

        int longestPalindromeIndex=0, longestPalindromeLength=0;
        for (var i = 0; i < length; i++)
        {
            if (longestPalindromeLength >= length - i) break;
            for (var j = length - i; j > 0; j--)
            {
                if (longestPalindromeLength >= j) break;
                if (IsPalindrome(i, j) && j > longestPalindromeLength)
                {
                    longestPalindromeIndex = i;
                    longestPalindromeLength = j;
                }
            }
        }

        return s.Substring(longestPalindromeIndex, longestPalindromeLength);

        bool IsPalindrome(int startIndex, int leng)
        {
            if (leng == 1) return true;
            var middle = leng / 2;
            for (var i = 0; i < middle; i++)
            {
                if (s[startIndex + i] != s[startIndex + leng - i - 1]) return false;
            }

            return true;
        }
    }
}