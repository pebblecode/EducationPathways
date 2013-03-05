namespace EducationPathways.Graphs
{
    using System;
    using Domain;
    using Graph;
    using NUnit.Framework;
    using SampleData;

    [TestFixture]
    public class GraphBuilderTests
    {
        [Test]
        public void foo()
        {
            var root = new SampleDataGenerator().Generate();
        }
    }
}
