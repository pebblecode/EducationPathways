﻿namespace EducationPathways.SampleData
{
    using System;
    using Domain;
    using Graph;

    public class SampleDataGenerator
    {
        public INode Generate()
        {
            var graph = new GraphBuilder(1000)
                .Add(1000, new Syllabus("Mathematics"), 1001)
                    .Add(1001, new Subject("Algebra"), 10011)
                        .Add(10011, new Topic("Introduction to algebra"), 10012)
                        .Add(10012, new Topic("Linear equations"), 10013)
                        .Add(10013, new Topic("Linear inequalities"), 10014)
                        .Add(10014, new Topic("Graphing points, equations and inequalities"), 10015)
                        .Add(10015, new Topic("Systems of equations and inequalities"), 10016)

                        .Add(10016, new Topic("Functions"), 10017)
                        .Add(10016, new Topic("Quadratics"), 10017)
                        .Add(10017, new Topic("Exponent expressions and equations"), 10018)
                        .Add(10017, new Topic("Polynomials"), 10018)
                        .Add(10018, new Topic("Ratios and rational expressions"), 10019)

                        .Add(10019, new Topic("Logarithms"), 1002)
                        .Add(10019, new Topic("Conic sections"), 1002)
                        .Add(10019, new Topic("Matrices"), 1002)
                        .Add(10019, new Topic("Imaginary and complex numbers"), 1002)

                    .Add(1002, new Subject("Linear Algebra"), 10021)
                        .Add(10021, new Topic("Vectors and spaces"), 1003)
                        .Add(10022, new Topic("Matrix transformations"), 1003)
                        .Add(10023, new Topic("Alternate coordinate systems (bases)"), 1003)

                    .Add(1003, new Subject("Geometry"), 10031)
                        .Add(10031, new Topic("Circles"), 10032)
                        .Add(10032, new Topic("Angles"), 10033)
                        .Add(10032, new Topic("Triangles"), 10033)

                        .Add(10033, new Topic("Points, lines and planes"), 10034)
                        .Add(10033, new Topic("Angles and intersecting lines"), 10034)
                        .Add(10033, new Topic("Congruent triangles"), 10034)
                        .Add(10033, new Topic("Perimeter, area and volume"), 10034)

                        .Add(10034, new Topic("Similarity"), 1004)
                        .Add(10034, new Topic("Right triangles"), 1004)
                        .Add(10034, new Topic("Special properties and parts of triangles"), 1004)
                        .Add(10034, new Topic("Quadrilaterals"), 1004)

                    .Add(1004, new Subject("Trigonometry"), 10041)
                        .Add(10041, new Topic("Graphing lines"), 10042)
                        .Add(10042, new Topic("Functions and their graphs"), 10043)
                        .Add(10043, new Topic("Polynomial and rational functions"), 10044)

                        .Add(10044, new Topic("Exponential and logarithmic functions"), 10045)
                        .Add(10044, new Topic("Basic trigonometry"), 10045)
                        .Add(10044, new Topic("Trig identities and examples"), 10045)

                        .Add(10045, new Topic("Parametric equations and polar coordinates"), 10046)
                        .Add(10045, new Topic("Conic sections"), 10046)
                        .Add(10045, new Topic("Sequences and induction"), 10046)

                        .Add(10046, new Topic("Probability and combinatorics"), 10047)
                        .Add(10047, new Topic("Imaginary and complex number"), 10048)
                        .Add(10048, new Topic("Hyperbolic trig functions"), 1005)

                    .Add(1005, new Subject("Discrete Maths"), 10052)
                        .Add(10052, new Topic("Set theory"), 10053)
                        .Add(10053, new Topic("Number theory"), 10054)
                        .Add(10054, new Topic("Graph theory"), 2000)

                .Add(2000, new Syllabus("Computer Science"), 2001)
                    .Add(2001, new Subject("Logic"), 20011)
                        .Add(20011, new Topic("Boolean logic"), 20012)
                        .Add(20012, new Topic("Statements and expressions"), 20013)
                        .Add(20013, new Topic("Pattern matching"), 0);

            return graph.Build();
        }
    }
}