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
    /// 1. HowMuch Command
    /// 2. each static method as a Public API provider of current command.
    /// 3. the purpose of directive was separate Action from Data.
    /// 4. the inherit means Which Directive will be supported by current command.
    /// </summary>
    public class HowMuchCommand : Command<HowMuchCommandDirective>
    {
        public HowMuchCommand(HowMuchCommandDirective directive) : base(directive)
        {

        }

        public override object Execute()
        {
            return $"{string.Join(" ", this._directive.RomainNumberAlias)} is {this._directive.RomanCalculator.Value.ToString()}";
        }
    }

    /// <summary>
    /// 1. HowMuch Command Directive.
    /// 2. the inherit means Which Command can be executed by current directive.
    /// </summary>
    public class HowMuchCommandDirective : CommandDirective<HowMuchCommand>
    {
        public HowMuchCommandDirective(string content) : base(content)
        {
        }

        public List<string> RomainNumberAlias
        {
            get
            {
                var splits = this.Content.TrimEnd('?').Trim().Split(' ').ToList();
                int isIndex = splits.IndexOf(splits.FirstOrDefault(o => o.Equals("is", StringComparison.InvariantCultureIgnoreCase)));
                var romainNumberAlias = splits.GetRange(isIndex + 1, splits.Count - (isIndex + 1));
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

        public override HowMuchCommand Command
        {
            get
            {
                return new HowMuchCommand(this);
            }
        }
    }
}
