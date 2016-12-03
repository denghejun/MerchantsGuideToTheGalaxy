using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Tests
{
    [TestFixture]
    public class UnknownCommand
    {
        [Test]
        public void SetProductPrice()
        {
            DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
            DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
            DirectiveProxy<UnitPriceCommandDirective>.Create("glob glob Silver is 34 Credits").Command.Execute();
            var response = DirectiveProxy<UnknownCommandDirective>.Create("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?").Command.Execute();

            Assert.That(response?.ToString(), Is.EqualTo("I have no idea what you are talking about"));
        }
    }
}
