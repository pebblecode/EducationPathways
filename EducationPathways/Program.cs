using System;
using System.Collections.Generic;

namespace EducationPathways
{
    using Domain;

    public class Program
    {
        public static void Main()
        {
            var algebra = new Subject("Algebra")
                {
                    NextNodes =
                        new List<Topic> {
                            new Topic("Introduction to algebra"),
                            new Topic("Linear equations"),
                            new Topic("Linear inequalities"),
                            new Topic("Graphing points, equations and inequalities"),
                            new Topic("Systems of equations and inequalities"),

                            new Topic("Functions"),
                            new Topic("Quadratics"),
                            new Topic("Exponent expressions and equations"),
                            new Topic("Polynomials"),
                            new Topic("Ratios and rational expressions"),
                            new Topic("Logarithms"),
                            new Topic("Conic sections"),
                            new Topic("Matrices"),
                            new Topic("Imaginary and complex numbers")
                        }
                };

            var linearAlgebra = new Subject("Linear Algebra")
                {
                    NextNodes = 
                        new List<Topic>
                        {
                            new Topic("Vectors and spaces"),
                            new Topic("Matrix transformations"),
                            new Topic("Alternate coordinate systems (bases)")
                        }
                };

            var geometry = new Subject("Geometry")
                {
                    NextNodes = new List<Topic>
                        {
                            new Topic("Circles"),
                            new Topic("Angles"),
                            new Topic("Triangles"),

                            new Topic("Points, lines and planes"),
                            new Topic("Angles and intersecting lines"),
                            new Topic("Congruent triangles"),
                            new Topic("Perimeter, area and volume"),

                            new Topic("Similarity"),
                            new Topic("Right triangles"),
                            new Topic("Special properties and parts of triangles"),
                            new Topic("Quadrilaterals")
                        }
                };

            var trigonometry = new Subject("Trigonometry")
                {
                    NextNodes = new List<Topic>
                        {
                            new Topic("Graphing lines"),
                            new Topic("Functions and their graphs"),
                            new Topic("Polynomial and rational functions"),

                            new Topic("Exponential and logarithmic functions"),
                            new Topic("Basic trigonometry"),
                            new Topic("Trig identities and examples"),

                            new Topic("Parametric equations and polar coordinates"),
                            new Topic("Conic sections"),
                            new Topic("Sequences and induction"),

                            new Topic("Probability and combinatorics"),
                            new Topic("Imaginary and complex number"),
                            new Topic("Hyperbolic trig functions")
                        }
                };

            var discrete = new Subject("Discrete Maths")
                {
                    NextNodes = new List<Topic>
                        {
                            new Topic("Logic"),
                            new Topic("Set theory"),
                            new Topic("Number theory"),
                            new Topic("Graph theory")
                        }
                };

            var computerScience = new Syllabus("Computer Science")
                {
                    NextNodes = new List<Subject>
                        {
                            new Subject("Logic")
                                {
                                    NextNodes = new List<Topic>
                                        {
                                            new Topic("Boolean logic"),
                                            new Topic("Statements and expressions"),
                                            new Topic("If-then-else"),
                                            new Topic("Pattern matching")
                                        }
                                }
                        }
                };
        }
    }
}
