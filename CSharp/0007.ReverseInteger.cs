using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class ReverseIntegerSolution : BaseSolution
{
    public override string ProblemName => "Reverse Integer";
    public override string ProblemDescription => "Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.\n\nAssume the environment does not allow you to store 64-bit integers (signed or unsigned).\n\n \n\nExample 1:\n\nInput: x = 123\nOutput: 321\nExample 2:\n\nInput: x = -123\nOutput: -321\nExample 3:\n\nInput: x = 120\nOutput: 21\n \n\nConstraints:\n\n-231 <= x <= 231 - 1";
    public override string ProblemUrl => "https://leetcode.com/problems/reverse-integer";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity { get; }
    public override TimeComplexity TimeComplexity { get; }

    public int Reverse(int x)
    {
        if (x == int.MinValue) return 0;
        var isNegative = x < 0;
        x = isNegative ? -x : x;
        if (x < 10) return isNegative ? -x : x;

        var str = x.ToString();
        var result = string.Empty;
        for (var i = str.Length - 1; i >= 0; i--)
        {
            result += str[i];
        }

        result = result.TrimStart('0');
        if (result.Length == 10)
        {
            var maxInt32Str = int.MaxValue.ToString();
            var isInt64 = false;
            var allEqual = false;
            for (var i = 0; i < 10; i++)
            {
                if (result[i] > maxInt32Str[i] && (allEqual || i == 0))
                {
                    isInt64 = true;
                    break;
                }

                allEqual = (allEqual || i == 0) && result[i] == maxInt32Str[i];
            }

            if (isInt64) return 0;
        }

        return isNegative ? -int.Parse(result) : int.Parse(result);
    }
}