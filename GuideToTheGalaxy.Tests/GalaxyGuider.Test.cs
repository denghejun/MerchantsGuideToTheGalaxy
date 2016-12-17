using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Tests
{
    [TestFixture]
    public class GalaxyGuiderTest
    {
        [Test]
        public void inputDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.txt");
            var responses = GalaxyGuider.SolveFromFile(filePath);
            Assert.That(responses, Is.Not.Null);
            Assert.That(responses.Where(o => !string.IsNullOrEmpty(o.Message?.Trim())).Count(), Is.EqualTo(5));
            Assert.That(responses.Where(o => !string.IsNullOrEmpty(o.Message?.Trim())).FirstOrDefault().Message, Is.EqualTo("pish tegj glob glob is 42"));
        }
    }
}
