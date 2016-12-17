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
    public class HowManyCommandStrategy : ICommandStrategy
    {
        public bool CanExecute(string content)
        {
            var splitedDesc = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return content.StartsWith("how many", StringComparison.InvariantCultureIgnoreCase);
        }

        public GuideResponse Execute(string content)
        {
            return new GuideResponse()
            {
                Message = DirectiveProxy<HowManyCommandDirective>.Create(content).Command.Execute()?.ToString()
            };
        }
    }
}
