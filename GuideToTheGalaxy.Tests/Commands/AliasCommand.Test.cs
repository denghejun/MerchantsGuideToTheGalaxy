using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Tests.Commands
{
    [TestFixture]
    public class AliasCommandTest
    {
        [Test]
        public void SetAliasForRomanNumber()
        {
            var romanNumber = DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute() as RomanNumber;
            Assert.That(romanNumber != null);
            Assert.That(romanNumber.Symbol == SymbolEnum.I);
            Assert.That(romanNumber.Value == 1);
            Assert.That(romanNumber.Alias == "glob");
            Assert.That(AliasCommand.GetRomanNumberByAlias("glob") != null);
        }
    }
}
