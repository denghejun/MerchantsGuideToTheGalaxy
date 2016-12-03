using GuideToTheGalaxy.Core;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    /// <summary>
    /// 1. HowMany Command
    /// 2. each static method as a Public API provider of current command.
    /// 3. the purpose of directive was separate Action from Data.
    /// 4. the inherit means Which Directive will be supported by current command.
    /// </summary>
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

    /// <summary>
    /// 1. HowMany Command Directive.
    /// 2. the inherit means Which Command can be executed by current directive.
    /// </summary>
    public class HowManyCommandDirective : CommandDirective<HowManyCommand>
    {
        public HowManyCommandDirective(string content) : base(content)
        {
        }

        public string ProductName
        {
            get
            {
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
