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
    public class UnknownCommandStrategy : ICommandStrategy
    {
        public bool CanExecute(string content)
        {
            return true;
        }

        public GuideResponse Execute(string content)
        {
            return new GuideResponse()
            {
                Message = DirectiveProxy<UnknownCommandDirective>.Create(content).Command.Execute()?.ToString()
            };
        }
    }
}
