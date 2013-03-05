using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EducationPathways.Domain;

namespace EducationPathways.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ViewBag.Data = FlattenNode(new Subject("Systems of equations and inequalities"){
                NextNodes = new List<INode>
                {
                    new Subject("Graphing points, equations and inequalities"),
                    new Subject("Systems of equations and inequalities"),
                    new Subject("Functions"){ NextNodes = new List<INode>
                        {
                            new Subject("Exponent expressions and equations"),
                            new Subject("Ratios and rational expressions"),
                            new Subject("Imaginary and complex numbers")
                        }}
                }});

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
            return FlattenNode(new StringBuilder(), node).ToString();
        }

        public StringBuilder FlattenNode(StringBuilder builder, INode node)
        {
            if (node == null) return builder;

            builder.AppendFormat(@"id: '{0}',
                name: '{1}',
                data: {{}},
                children: [", node.Name, node.Name);

            var first = true;
            if (node.NextNodes != null)
                foreach (var subnode in node.NextNodes)
                {
                    if (!first)
                        builder.Append(@",");
                    builder.Append("{");
                    FlattenNode(builder, subnode);
                    builder.Append("}");

                    first = false;
                }

            builder.Append(@"]");

            return builder;
        }
    }
}
