namespace EducationPathways.Graphs
{
    using System;
    using Domain;
    using Graph;
    using NUnit.Framework;

    [TestFixture]
    public class GraphBuilderTests
    {
        [Test]
        public void foo()
        {
            var graph = new GraphBuilder(100)
                .Add(100, new Subject("Algebra"), 101)

                .Add(101, new Topic("Introduction to algebra"), 102)
                .Add(102, new Topic("Linear equations"), 103)
                .Add(103, new Topic("Linear inequalities"), 104)
                .Add(104, new Topic("Graphing points, equations and inequalities"), 105)
                .Add(105, new Topic("Systems of equations and inequalities"), 111)

                .Add(111, new Topic("Functions"), 112)
                .Add(111, new Topic("Quadratics"), 112)
                .Add(111, new Topic("Exponent expressions and equations"), 112)
                .Add(111, new Topic("Polynomials"), 112)
                .Add(111, new Topic("Ratios and rational expressions"), 112)

                .Add(112, new Topic("Logarithms"), 0)
                .Add(112, new Topic("Conic sections"), 0)
                .Add(112, new Topic("Matrices"), 0)
                .Add(112, new Topic("Imaginary and complex numbers"), 0);

            var root = graph.Build();
        }
    }
}
