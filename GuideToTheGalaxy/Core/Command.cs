using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Core
{
    public abstract class Command
    {
        public abstract object Execute();
    }

    public abstract class Command<TDirective> : Command where TDirective : CommandDirective
    {
        protected TDirective _directive;

        public Command(TDirective directive)
        {
            this._directive = directive;
        }
    }
}
