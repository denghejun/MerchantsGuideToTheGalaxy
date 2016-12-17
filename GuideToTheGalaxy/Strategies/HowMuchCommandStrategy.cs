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
    public class HowMuchCommandStrategy : ICommandStrategy
    {
        public bool CanExecute(string content)
        {
            var splitedDesc = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return content.StartsWith("how much", StringComparison.InvariantCultureIgnoreCase) && splitedDesc.Where(o => !new[] { "how", "much", "is", "?" }.Contains(o)).All(m => AliasCommand.GetAllRomainNumbers().Any(r => r.Alias == m));
        }

        public GuideResponse Execute(string content)
        {
            return new GuideResponse()
            {
                Message = DirectiveProxy<HowMuchCommandDirective>.Create(content).Command.Execute()?.ToString()
            };
        }
    }
}
