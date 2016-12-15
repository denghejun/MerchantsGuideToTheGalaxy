using GuideToTheGalaxy.Core;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    public class UnitPriceCommand : Command<UnitPriceCommandDirective>
    {
        public UnitPriceCommand(UnitPriceCommandDirective directive) : base(directive)
        {

        }

        protected static readonly Dictionary<string, decimal> UnitPrices = new Dictionary<string, decimal>();

        public override object Execute()
        {
            if (UnitPriceCommand.UnitPrices.ContainsKey(this._directive.ProductName))
            {
                UnitPriceCommand.UnitPrices[this._directive.ProductName] = this._directive.UnitPrice;
            }
            else
            {
                UnitPriceCommand.UnitPrices.Add(this._directive.ProductName, this._directive.UnitPrice);
            }

            return UnitPriceCommand.UnitPrices[this._directive.ProductName];
        }

        public static decimal GetUnitPriceByProductName(string name)
        {
            return UnitPriceCommand.UnitPrices.ContainsKey(name?.Trim()) ? UnitPriceCommand.UnitPrices[name?.Trim()] : 0;
        }
    }

    public class UnitPriceCommandDirective : CommandDirective<UnitPriceCommand>
    {
        public UnitPriceCommandDirective(string content) : base(content)
        {
        }

        public string ProductName
        {
            get
            {
                var splits = this.Content.Split(' ').ToList();
                int isIndex = splits.IndexOf(splits.FirstOrDefault(o => o.Equals("is", StringComparison.InvariantCultureIgnoreCase)));
                return splits[isIndex - 1];
            }
        }

        public int ProductCount
        {
            get
            {
                var splits = this.Content.Split(' ').ToList();
                int isIndex = splits.IndexOf(splits.FirstOrDefault(o => o.Equals("is", StringComparison.InvariantCultureIgnoreCase)));
                return int.Parse(splits[isIndex + 1]);
            }
        }

        public List<string> RomainNumberAlias
        {
            get
            {
                var splits = this.Content.Split(' ').ToList();
                var romainNumberAlias = splits.GetRange(0, splits.IndexOf(this.ProductName));
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

        public decimal UnitPrice
        {
            get
            {
                return (decimal)this.ProductCount  / this.RomanCalculator.Value;
            }
        }

        public override UnitPriceCommand Command
        {
            get
            {
                return new UnitPriceCommand(this);
            }
        }
    }
}
