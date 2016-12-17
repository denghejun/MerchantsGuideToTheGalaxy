using GuideToTheGalaxy.Core;
using GuideToTheGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    public class UnknownCommand : Command<UnknownCommandDirective>
    {
        public UnknownCommand(UnknownCommandDirective directive) : base(directive)
        {

        }

        public override object Execute()
        {
            return GuideResponse.Unknown.Message;
        }
    }

    public class UnknownCommandDirective : CommandDirective<UnknownCommand>
    {
        public UnknownCommandDirective(string content) : base(content)
        {
        }

        public override UnknownCommand Command
        {
            get
            {
                return new UnknownCommand(this);
            }
        }
    }
}
