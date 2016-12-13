using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideConsole.GuideMenu
{
    public class ExitMenu : GuideMenu
    {
        public override string Content
        {
            get
            {
                return "Input 'exit' to quit";
            }
        }

        public override string Tips
        {
            get
            {
                return "Are you sure to exit [y/n] ?";
            }
        }

        public override bool Do(string input)
        {
            if (input.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Environment.Exit(0);
            }

            return true;
        }
    }
}
