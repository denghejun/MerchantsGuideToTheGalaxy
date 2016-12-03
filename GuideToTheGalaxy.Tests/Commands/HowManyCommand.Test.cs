using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Tests.Commands
{
    [TestFixture]
    public class HowManyCommand
    {
        [Test]
        public void CalculateProductAmount()
        {
            DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
            DirectiveProxy<UnitPriceCommandDirective>.Create("glob glob Silver is 34 Credits").Command.Execute();
            var response = DirectiveProxy<HowManyCommandDirective>.Create("how many Credits is glob prok Silver ?").Command.Execute();

            Assert.That(response?.ToString() == "glob prok Silver is 68 Credits");
        }
    }
}
