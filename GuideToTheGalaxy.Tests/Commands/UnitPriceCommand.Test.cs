using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;

namespace GuideToTheGalaxy.Tests.Commands
{
    [TestFixture]
    public class UnitPriceCommandTest
    {
        [Test]
        public void SetProductPrice()
        {
            DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
            var unitPrice = DirectiveProxy<UnitPriceCommandDirective>.Create("glob glob Silver is 34 Credits").Command.Execute();

            Assert.That((decimal)unitPrice == 17);
            Assert.That(UnitPriceCommand.GetUnitPriceByProductName("Silver") == 17);
        }
    }
}
