using dotNetExt;
using GuideToTheGalaxy;
using System;

namespace GuideConsole.GuideMenus
{
    public class InputDataFromFileMenu : GuideMenu
    {
        public override string Content
        {
            get
            {
                return "Input Data From File";
            }
        }

        public override string Tips
        {
            get
            {
                return "Please input a full file path:";
            }
        }

        public override bool Do(string input)
        {
            var responses = GalaxyGuider.SolveFromFile(input?.Trim());
            if (!responses.IsNullOrEmpty())
            {
                foreach (var response in responses)
                {
                    if (!response.Message.IsNullOrWhiteSpace())
                    {
                        Console.WriteLine(response.Message);
                    }
                }
            }

            return true;
        }
    }
}
