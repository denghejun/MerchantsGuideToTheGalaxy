using GuideToTheGalaxy.Commands;
using GuideToTheGalaxy.Core;
using NUnit.Framework;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Tests
{
    [TestFixture]
    public class AliasCommandTest
    {
        [Test]
        public void SetAliasForRomanNumber()
        {
            var romanNumber = DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute() as RomanNumber;
            Assert.That(romanNumber, Is.Not.Null);
            Assert.That(romanNumber.Symbol, Is.EqualTo(SymbolEnum.I));
            Assert.That(romanNumber.Value, Is.EqualTo(1));
            Assert.That(romanNumber.Alias, Is.EqualTo("glob"));
            Assert.That(AliasCommand.GetRomanNumberByAlias("glob"), Is.Not.Null);
        }
    }
}
