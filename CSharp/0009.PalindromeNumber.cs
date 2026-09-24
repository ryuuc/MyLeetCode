using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class PalindromeNumberSolution : BaseSolution
{
    public override string ProblemName => "Palindrome Number";

    public override string ProblemDescription =>
        "Given an integer x, return true if x is a palindrome, and false otherwise.\n\n \n\nExample 1:\n\nInput: x = 121\nOutput: true\nExplanation: 121 reads as 121 from left to right and from right to left.\nExample 2:\n\nInput: x = -121\nOutput: false\nExplanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.\nExample 3:\n\nInput: x = 10\nOutput: false\nExplanation: Reads 01 from right to left. Therefore it is not a palindrome.\n \n\nConstraints:\n\n-231 <= x <= 231 - 1\n \n\nFollow up: Could you solve it without converting the integer to a string?";

    public override string ProblemUrl => "https://leetcode.com/problems/palindrome-number";
    public override Level ProblemLevel => Level.Easy;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LogarithmicOrder; //O(log 10 x)

    public bool IsPalindrome(int x)
    {
        // 1. 负数肯定不是回文数
        // 2. 如果末位是 0 且数值不为 0（如 10, 200），肯定也不是回文数
        if (x < 0 || (x % 10 == 0 && x != 0)) {
            return false;
        }

        int revertedNumber = 0;
        // 当原始数字小于或等于翻转数字时，说明已经处理了一半以上的位数
        while (x > revertedNumber) {
            revertedNumber = revertedNumber * 10 + x % 10;
            x /= 10;
        }

        // 偶数长度：x == revertedNumber (例如 12 == 12)
        // 奇数长度：x == revertedNumber / 10 (例如 1 == 12 / 10，忽略中间的数字)
        return x == revertedNumber || x == revertedNumber / 10;
    }
    /// <summary>
    /// O(log 10 x)
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool IsPalindrome_v1(int x)
    {
        if (x < 0) return false;
        if (x < 10) return true;
        var dic = new Dictionary<int, int>();
        int len = 0;
        while (x > 0)
        {
            var point = x % 10;
            dic.Add(len, point);
            x /= 10;
            len++;
        }

        var count = dic.Count;
        var round = count / 2;
        for (var i = 0; i < round; i++)
        {
            if (dic[i] != dic[count - i - 1]) return false;
        }

        return true;
    }
}