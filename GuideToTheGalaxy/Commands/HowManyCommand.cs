﻿using GuideToTheGalaxy.Core;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    public class HowManyCommand : Command<HowManyCommandDirective>
    {
        public HowManyCommand(HowManyCommandDirective directive) : base(directive)
        {

        }

        public override object Execute()
        {
            return $"{string.Join(" ", this._directive.RomainNumberAlias)} {this._directive.ProductName} is {this._directive.TotalAmount} Credits";
        }
    }

    public class HowManyCommandDirective : CommandDirective<HowManyCommand>
    {
        public HowManyCommandDirective(string content) : base(content)
        {
        }

        protected override void Validate(string content)
        {
            if (!new Regex(@"^how many .+\?$").IsMatch(content))
            {
                throw new Exception("valid input.");
            }
        }

        public string ProductName
        {
            get
            {
                //how many Credits is glob prok Silver ?
                var regex = new Regex(@"^how many .+\? \b(?<ProductName>\\w*)\b?$");
                var g = regex.Match(this.Content);
                var splits = this.Content.TrimEnd('?').Trim().Split(' ').ToList();
                return splits.Last();
            }
        }

        public List<string> RomainNumberAlias
        {
            get
            {
                var splits = this.Content.TrimEnd('?').Trim().Split(' ').ToList();
                int isIndex = splits.IndexOf(splits.FirstOrDefault(o => o.Equals("is", StringComparison.InvariantCultureIgnoreCase)));
                var romainNumberAlias = splits.GetRange(isIndex + 1, splits.Count - (isIndex + 1) - 1);
                return romainNumberAlias;
            }
        }

        public RomanCalculator RomanCalculator
        {
            get
            {
                var calculator = new RomanCalculator();
                foreach (var alias in this.RomainNumberAlias)
                {
                    calculator.Add(AliasCommand.GetRomanNumberByAlias(alias));
                }

                return calculator;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this.RomanCalculator.Value * UnitPriceCommand.GetUnitPriceByProductName(this.ProductName);
            }
        }

        public override HowManyCommand Command
        {
            get
            {
                return new HowManyCommand(this);
            }
        }
    }
}
