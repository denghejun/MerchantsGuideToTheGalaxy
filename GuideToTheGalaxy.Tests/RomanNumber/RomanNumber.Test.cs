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
    public class RomanNumberTest
    {
        [Test]
        public void CalculateValue()
        {
            var calculator = new RomanCalculator();
            calculator.Add(RomanNumber.I);
            calculator.Add(RomanNumber.X);
            var value = calculator.Value;

            Assert.That(value, Is.EqualTo(9));
        }

        [Test]
        public void CalculateFailed()
        {
            Assert.That(() =>
            {
                var calculator = new RomanCalculator();
                calculator.Add(RomanNumber.I);
                calculator.Add(RomanNumber.M);
                var value = calculator.Value;
            }, Throws.Exception.With.Message.EqualTo($"{RomanNumber.I.Symbol} can be only subtracted from {SymbolEnum.V} {SymbolEnum.X}."));
        }
    }
}
