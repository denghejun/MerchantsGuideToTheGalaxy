using GuideToTheGalaxy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    /// <summary>
    /// 1. Unknown Command
    /// 2. each static method as a Public API provider of current command.
    /// 3. the purpose of directive was separate Action from Data.
    /// 4. the inherit means Which Directive will be supported by current command.
    /// </summary>
    public class UnknownCommand : Command<UnknownCommandDirective>
    {
        public UnknownCommand(UnknownCommandDirective directive) : base(directive)
        {

        }

        public override object Execute()
        {
            return "I have no idea what you are talking about";
        }
    }

    /// <summary>
    /// 1. Unknown Command Directive.
    /// 2. the inherit means Which Command can be executed by current directive.
    /// </summary>
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
