using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Core
{
    public static class DirectiveProxy<TDirective> where TDirective : CommandDirective
    {
        public static TDirective Create(string content)
        {
            return (TDirective)Activator.CreateInstance(typeof(TDirective), new object[] { content });
        }
    }
}
