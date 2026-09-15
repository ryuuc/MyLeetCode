namespace MyLeetCode.CSharp.BaseModels;

public abstract class BaseSolution
{
    public abstract string ProblemName { get; }
    public abstract string ProblemDescription { get; }
    public abstract string ProblemUrl { get; }
    public abstract Level ProblemLevel { get; }

    public abstract SpaceComplexity SpaceComplexity { get; }
    public abstract TimeComplexity TimeComplexity { get; }
}