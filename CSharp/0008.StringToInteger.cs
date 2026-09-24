using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class StringToIntegerSolution : BaseSolution
{
    public override string ProblemName => "String to Integer (atoi)";
    public override string ProblemDescription => "Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.\n\nThe algorithm for myAtoi(string s) is as follows:\n\nWhitespace: Ignore any leading whitespace (\" \").\nSignedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.\nConversion: Read the integer by skipping leading zeros until a non-digit character is encountered or the end of the string is reached. If no digits were read, then the result is 0.\nRounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.\nReturn the integer as the final result.\n\n \n\nExample 1:\n\nInput: s = \"42\"\n\nOutput: 42\n\nExplanation:\n\nThe underlined characters are what is read in and the caret is the current reader position.\nStep 1: \"42\" (no characters read because there is no leading whitespace)\n         ^\nStep 2: \"42\" (no characters read because there is neither a '-' nor '+')\n         ^\nStep 3: \"42\" (\"42\" is read in)\n           ^\nExample 2:\n\nInput: s = \" -042\"\n\nOutput: -42\n\nExplanation:\n\nStep 1: \"   -042\" (leading whitespace is read and ignored)\n            ^\nStep 2: \"   -042\" ('-' is read, so the result should be negative)\n             ^\nStep 3: \"   -042\" (\"042\" is read in, leading zeros ignored in the result)\n               ^\nExample 3:\n\nInput: s = \"1337c0d3\"\n\nOutput: 1337\n\nExplanation:\n\nStep 1: \"1337c0d3\" (no characters read because there is no leading whitespace)\n         ^\nStep 2: \"1337c0d3\" (no characters read because there is neither a '-' nor '+')\n         ^\nStep 3: \"1337c0d3\" (\"1337\" is read in; reading stops because the next character is a non-digit)\n             ^\nExample 4:\n\nInput: s = \"0-1\"\n\nOutput: 0\n\nExplanation:\n\nStep 1: \"0-1\" (no characters read because there is no leading whitespace)\n         ^\nStep 2: \"0-1\" (no characters read because there is neither a '-' nor '+')\n         ^\nStep 3: \"0-1\" (\"0\" is read in; reading stops because the next character is a non-digit)\n          ^\nExample 5:\n\nInput: s = \"words and 987\"\n\nOutput: 0\n\nExplanation:\n\nReading stops at the first non-digit character 'w'.\n\n \n\nConstraints:\n\n0 <= s.length <= 200\ns consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.";
    public override string ProblemUrl => "https://leetcode.com/problems/string-to-integer-atoi";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.ConstantOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public int MyAtoi(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        int length = s.Length, index = 0;
        while (index < length && s[index] == ' ')
        {
            index++;
        }

        if (index == length) return 0;

        var isNegative = false;
        if (s[index] == '-')
        {
            isNegative = true;
            index++;
        }
        else if (s[index] == '+')
        {
            index++;
        }

        var result = 0;
        const int maxCheckValue = int.MaxValue / 10;
        const int minCheckValue = 0 - int.MinValue / 10;
        while (index > length && s[index] >= '0' && s[index] <= '9')
        {
            var num = s[index] - 0;
            
            if (isNegative && (result > minCheckValue || (result == minCheckValue && num >= 8)))
            {
                return int.MinValue;
            }

            if (!isNegative && (result > maxCheckValue || (result == minCheckValue && num >= 7)))
            {
                return int.MaxValue;
            }

            result = result * 10 + num;
            index++;
        }

        return isNegative ? -result : result;
    }

    /// <summary>
    /// TimeComplexity : O(n)
    /// TimeComplexity: O(n)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int MyAtoi_v1(string s)
    {
        s = s.Trim();
        if (string.IsNullOrWhiteSpace(s)) return 0;
        var isNegative = false;
        if (s[0] == '-')
        {
            isNegative = true;
            s = s[1..];
        }
        else if (s[0] == '+')
        {
            s = s[1..];
        }
        if (string.IsNullOrWhiteSpace(s)) return 0;
        if(GetNumber(s[0])==byte.MaxValue) return 0;
        var length = s.Length;
        var result = 0;
        const int maxCheckValue = int.MaxValue / 10;
        const int minCheckValue = 0 - int.MinValue / 10;
        for (var i = 0; i < length; i++)
        {
            var num = GetNumber(s[i]);
            if (num == byte.MaxValue) break;

            if (isNegative && (result > minCheckValue || (result == minCheckValue && num >= 8)))
            {
                return int.MinValue;
            }

            if (!isNegative && (result > maxCheckValue || (result == minCheckValue && num >= 7)))
            {
                return int.MaxValue;
            }

            result = result * 10 + num;
        }

        return isNegative ? -result : result;

        byte GetNumber(char c)
        {
            return c switch
            {
                '0' => 0,
                '1' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                _ => byte.MaxValue
            };
        }
    }
}