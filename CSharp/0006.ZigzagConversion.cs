using System.Text;
using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class ZigzagConversionSolution : BaseSolution
{
    public override string ProblemName => "Zigzag Conversion";

    public override string ProblemDescription =>
        "The string \"PAYPALISHIRING\" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)\n\nP   A   H   N\nA P L S I I G\nY   I   R\nAnd then read line by line: \"PAHNAPLSIIGYIR\"\n\nWrite the code that will take a string and make this conversion given a number of rows:\n\nstring convert(string s, int numRows);\n \n\nExample 1:\n\nInput: s = \"PAYPALISHIRING\", numRows = 3\nOutput: \"PAHNAPLSIIGYIR\"\nExample 2:\n\nInput: s = \"PAYPALISHIRING\", numRows = 4\nOutput: \"PINALSIGYAHRPI\"\nExplanation:\nP     I    N\nA   L S  I G\nY A   H R\nP     I\nExample 3:\n\nInput: s = \"A\", numRows = 1\nOutput: \"A\"\n \n\nConstraints:\n\n1 <= s.length <= 1000\ns consists of English letters (lower-case and upper-case), ',' and '.'.\n1 <= numRows <= 1000";

    public override string ProblemUrl => "https://leetcode.com/problems/zigzag-conversion/";
    public override Level ProblemLevel => Level.Medium;
    public override SpaceComplexity SpaceComplexity => SpaceComplexity.LinearOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public string Convert(string s, int numRows)
    {
        if (numRows <= 1 || string.IsNullOrEmpty(s)) return s;
        var sbArray = new List<StringBuilder>();
        for (var i = 0; i < numRows; i++)
        {
            sbArray.Add(new StringBuilder());
        }

        var length = s.Length;
        var rowIndex = 0;
        var goingUp = true;
        for (var i = 0; i < length; i++)
        {
            sbArray[rowIndex].Append(s[i]);
            if (rowIndex == numRows - 1)
            {
                goingUp = false;
                rowIndex--;
            }
            else if (rowIndex == 0)
            {
                goingUp = true;
                rowIndex++;
            }
            else
            {
                if (goingUp)
                {
                    rowIndex++;
                }
                else
                {
                    rowIndex--;
                }
            }
        }

        var result = new StringBuilder();
        for (var i = 0; i < numRows; i++)
        {
            result.Append(sbArray[i]);
        }

        return result.ToString();
    }

    /// <summary>
    /// Over-simulation
    /// SpaceComplexity = O(n)
    /// TimeComplexity = O(numRows * n)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public string Convert_v1(string s, int numRows)
    {
        if (numRows <= 1) return s;
        var charDic = new Dictionary<(int, int), int>();
        var length = s.Length;
        var round = length / (numRows + numRows - 2) + 1;
        var nextCharIndex = 0;
        for (var i = 0; i < round; i++)
        {
            var start = i * (numRows - 1);
            for (var j = 0; j < numRows; j++)
            {
                if (nextCharIndex >= length) break;
                charDic[(start, j)] = nextCharIndex;
                nextCharIndex++;
            }

            for (var j = 1; j < numRows - 1; j++)
            {
                if (nextCharIndex >= length) break;
                charDic[(start + j, numRows - j - 1)] = nextCharIndex;
                nextCharIndex++;
            }
        }

        var result = new StringBuilder();
        var width = (numRows - 1) * round;
        for (var i = 0; i < numRows; i++)
        {
            for (var j = 0; j < width; j++)
            {
                if (charDic.TryGetValue((j, i), out var ch))
                {
                    result.Append(s[ch]);
                }
            }
        }

        return result.ToString();
    }
}