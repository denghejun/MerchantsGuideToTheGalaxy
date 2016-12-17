using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Core
{
    public class CommandDirective
    {
        public CommandDirective(string content)
        {
            this.Content = content;
            this.Validate(content);
        }

        public string Content { get; private set; }

        protected virtual void Validate(string content)
        {

        }
    }

    public abstract class CommandDirective<TCommand> : CommandDirective where TCommand : Command
    {
        public CommandDirective(string content) : base(content)
        {
        }

        public abstract TCommand Command { get; }
    }
}
