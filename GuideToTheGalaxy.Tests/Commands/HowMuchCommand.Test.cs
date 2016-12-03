using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;

namespace GuideToTheGalaxy.Tests
{
    [TestFixture]
    public class HowMuchCommandTest
    {
        [Test]
        public void CalculateAmount()
        {
            DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
            var response = DirectiveProxy<HowMuchCommandDirective>.Create("how much is pish tegj glob glob ?").Command.Execute();

            Assert.That(response?.ToString(), Is.EqualTo("pish tegj glob glob is 42"));
        }
    }
}
