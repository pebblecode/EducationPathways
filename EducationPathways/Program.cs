using System;
using System.Collections.Generic;

namespace EducationPathways
{
    using Domain;
    using Graph;

    public class Program
    {
        public static void Main()
        {
            var graph = new GraphBuilder(100)
                .Add(100, new Subject("Algebra"), 101)

                .Add(101, new Topic("Introduction to algebra"), 111)
                .Add(102, new Topic("Linear equations"), 111)
                .Add(103, new Topic("Linear inequalities"), 111)
                .Add(104, new Topic("Graphing points, equations and inequalities"), 111)
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

            //var algebra = new Subject("Algebra")
            //    {
            //        NextNodes =
            //            new List<Topic> {
            //                new Topic("Introduction to algebra"),
            //                new Topic("Linear equations"),
            //                new Topic("Linear inequalities"),
            //                new Topic("Graphing points, equations and inequalities"),
            //                new Topic("Systems of equations and inequalities"),

            //                new Topic("Functions"),
            //                new Topic("Quadratics"),
            //                new Topic("Exponent expressions and equations"),
            //                new Topic("Polynomials"),
            //                new Topic("Ratios and rational expressions"),
            //                new Topic("Logarithms"),
            //                new Topic("Conic sections"),
            //                new Topic("Matrices"),
            //                new Topic("Imaginary and complex numbers")
            //            }
            //    };

            //var linearAlgebra = new Subject("Linear Algebra")
            //    {
            //        NextNodes = 
            //            new List<Topic>
            //            {
            //                new Topic("Vectors and spaces"),
            //                new Topic("Matrix transformations"),
            //                new Topic("Alternate coordinate systems (bases)")
            //            }
            //    };

            //var geometry = new Subject("Geometry")
            //    {
            //        NextNodes = new List<Topic>
            //            {
            //                new Topic("Circles"),
            //                new Topic("Angles"),
            //                new Topic("Triangles"),

            //                new Topic("Points, lines and planes"),
            //                new Topic("Angles and intersecting lines"),
            //                new Topic("Congruent triangles"),
            //                new Topic("Perimeter, area and volume"),

            //                new Topic("Similarity"),
            //                new Topic("Right triangles"),
            //                new Topic("Special properties and parts of triangles"),
            //                new Topic("Quadrilaterals")
            //            }
            //    };

            //var trigonometry = new Subject("Trigonometry")
            //    {
            //        NextNodes = new List<Topic>
            //            {
            //                new Topic("Graphing lines"),
            //                new Topic("Functions and their graphs"),
            //                new Topic("Polynomial and rational functions"),

            //                new Topic("Exponential and logarithmic functions"),
            //                new Topic("Basic trigonometry"),
            //                new Topic("Trig identities and examples"),

            //                new Topic("Parametric equations and polar coordinates"),
            //                new Topic("Conic sections"),
            //                new Topic("Sequences and induction"),

            //                new Topic("Probability and combinatorics"),
            //                new Topic("Imaginary and complex number"),
            //                new Topic("Hyperbolic trig functions")
            //            }
            //    };

            //var discrete = new Subject("Discrete Maths")
            //    {
            //        NextNodes = new List<Topic>
            //            {
            //                new Topic("Logic"),
            //                new Topic("Set theory"),
            //                new Topic("Number theory"),
            //                new Topic("Graph theory")
            //            }
            //    };

            //var computerScience = new Syllabus("Computer Science")
            //    {
            //        NextNodes = new List<Subject>
            //            {
            //                new Subject("Logic")
            //                    {
            //                        NextNodes = new List<Topic>
            //                            {
            //                                new Topic("Boolean logic"),
            //                                new Topic("Statements and expressions"),
            //                                new Topic("If-then-else"),
            //                                new Topic("Pattern matching")
            //                            }
            //                    }
            //            }
            //    };
        }
    }
}
