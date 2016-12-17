using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideToTheGalaxy.Models;
using RomanNumerals;
using GuideToTheGalaxy.Core;
using GuideToTheGalaxy.Commands;

namespace GuideToTheGalaxy.Strategies
{
    public class AliasCommandStrategy : ICommandStrategy
    {
        public bool CanExecute(string content)
        {
            var splitedDesc = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return splitedDesc.Count == 3 && RomanNumber.RomanNumbers.Contains(splitedDesc.Last());
        }

        public GuideResponse Execute(string content)
        {
            DirectiveProxy<AliasCommandDirective>.Create(content).Command.Execute()?.ToString();
            return GuideResponse.Empty;
        }
    }
}
