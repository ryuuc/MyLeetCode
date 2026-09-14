using System.ComponentModel;

namespace MyLeetCode.BaseModels;

public enum TimeComplexity : byte
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
    [Description("O(log n)")] LogarithmicOrder,

    /// <summary>
    /// O(n log n)
    /// </summary>
    [Description("O(n log n)")] LinearithmicOrder,

    /// <summary>
    /// O(n!)
    /// </summary>
    [Description("O(n!)")] FactorialOrder
}