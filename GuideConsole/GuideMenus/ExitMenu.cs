using System;

namespace GuideConsole.GuideMenus
{
    public class ExitMenu : GuideMenu
    {
        public override string Content
        {
            get
            {
                return "Exit";
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
