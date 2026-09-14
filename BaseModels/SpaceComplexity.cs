using System.ComponentModel;

namespace MyLeetCode.BaseModels;

/// <summary>
/// Space complexity measures the growth trend of memory space occupied by an algorithm as the data size increases.
/// This concept is very similar to time complexity, except that "running time" is replaced with "occupied memory space".
/// </summary>
public enum SpaceComplexity : byte
{
    /// <summary>
    /// O(1)
    /// </summary>
    [Description("O(1)")] ConstantOrder,
    /// <summary>
    /// O(n)
    /// </summary>
    [Description("O(n)")] LinearOrder,
    /// <summary>
    /// O(n^2)
    /// </summary>
    [Description("O(n^2)")] QuadraticOrder,
    /// <summary>
    /// O(2^n)
    /// </summary>
    [Description("O(2^n)")] ExponentialOrder,
    /// <summary>
    /// O(log n)
    /// </summary>
    [Description("O(log n)")] LogarithmicOrder
}