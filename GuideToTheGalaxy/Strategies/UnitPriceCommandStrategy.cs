using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideToTheGalaxy.Models;
using GuideToTheGalaxy.Core;
using GuideToTheGalaxy.Commands;

namespace GuideToTheGalaxy.Strategies
{
    public class UnitPriceCommandStrategy : ICommandStrategy
    {
        public bool CanExecute(string content)
        {
            var splitedDesc = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return splitedDesc.Last().Equals("Credits", StringComparison.InvariantCultureIgnoreCase);
        }

        public GuideResponse Execute(string content)
        {
            DirectiveProxy<UnitPriceCommandDirective>.Create(content).Command.Execute()?.ToString();
            return GuideResponse.Empty;
        }
    }
}
