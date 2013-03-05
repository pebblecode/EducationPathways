using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Windows.Media;
using EducationPathways.Domain;
using EducationPathways.SampleData;

namespace EducationPathways.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //ViewBag.Data = FlattenNode(new Subject("Systems of equations and inequalities")
            //{
            //    NextNodes = new List<INode>
            //    {
            //        new Subject("Graphing points, equations and inequalities"),
            //        new Subject("Systems of equations and inequalities"),
            //        new Subject("Functions"){ NextNodes = new List<INode>
            //            {
            //                new Subject("Exponent expressions and equations"),
            //                new Subject("Ratios and rational expressions"),
            //                new Subject("Imaginary and complex numbers")
            //            }}
            //    }
            //});

            ViewBag.Data = FlattenNode(new SampleDataGenerator().Generate());

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string FlattenNode(INode node)
        {
            return FlattenNode(new StringBuilder(), node, null, new List<string>()).ToString();
        }

        public StringBuilder FlattenNode(StringBuilder builder, INode node, string parentName, IList<string> names)
        {
            if (node == null) return builder;

            var nodeVariable = node.Name.ToLower().Replace(" ", "").Replace("(", "").Replace(")","").Replace(",","");
            if (!names.Contains(nodeVariable))
            {
                builder.AppendFormat("var {0} = graph.newNode({{label: '{1}', bold: '{2}'}});", nodeVariable, node.Name, node is Subject);
                names.Add(nodeVariable);

                if (parentName != null)
                    builder.AppendFormat("graph.newEdge({0}, {1}, {{color: '{2}'}});", parentName, nodeVariable, RandomPastelColorGenerator.Instance.GetNextBrush().Color.ToString());
            }


            if (node.NextNodes != null)
                foreach (var subnode in node.NextNodes)
                {
                    FlattenNode(builder, subnode, nodeVariable, names);
                }

            return builder;
        }

        public class RandomPastelColorGenerator
        {
            private readonly Random _random;

            public static RandomPastelColorGenerator Instance = new RandomPastelColorGenerator();

            public RandomPastelColorGenerator()
            {
                // seed the generator with 2 because
                // this gives a good sequence of colors
                const int RandomSeed = 2;
                _random = new Random(RandomSeed);
            }

            /// <summary>
            /// Returns a random pastel brush
            /// </summary>
            /// <returns></returns>
            public SolidColorBrush GetNextBrush()
            {
                SolidColorBrush brush = new SolidColorBrush(GetNext());
                // freeze the brush for efficiency
                brush.Freeze();

                return brush;
            }

            /// <summary>
            /// Returns a random pastel color
            /// </summary>
            /// <returns></returns>
            public Color GetNext()
            {
                // to create lighter colours:
                // take a random integer between 0 & 128 (rather than between 0 and 255)
                // and then add 127 to make the colour lighter
                byte[] colorBytes = new byte[3];
                colorBytes[0] = (byte)(_random.Next(128) + 127);
                colorBytes[1] = (byte)(_random.Next(128) + 127);
                colorBytes[2] = (byte)(_random.Next(128) + 127);

                Color color = new Color();

                // make the color fully opaque
                color.A = 255;
                color.R = colorBytes[0];
                color.B = colorBytes[1];
                color.G = colorBytes[2];

                return color;
            }
        }

    }
}
