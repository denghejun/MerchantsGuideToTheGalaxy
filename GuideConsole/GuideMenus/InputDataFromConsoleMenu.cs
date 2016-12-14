using dotNetExt;
using GuideToTheGalaxy;
using System;
using System.IO;

namespace GuideConsole.GuideMenus
{
    public class InputDataFromConsoleMenu : GuideMenu
    {
        private static readonly string TEMP_INPUTFILE_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.txt");

        static InputDataFromConsoleMenu()
        {
            File.Delete(TEMP_INPUTFILE_PATH);
        }

        public override string Content
        {
            get
            {
                return "Input Data From Console";
            }
        }

        public override string Tips
        {
            get
            {
                return "Please input data directly in console, and Press 'Enter' twice to execute.";
            }
        }

        public override bool Do(string input)
        {
            if (input.Trim().Equals(string.Empty))
            {
                var responses = GalaxyGuider.SolveFromFile(TEMP_INPUTFILE_PATH);
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

                File.Delete(TEMP_INPUTFILE_PATH);
                return true;
            }
            else
            {
                File.AppendAllLines(TEMP_INPUTFILE_PATH, new string[] { input });
                return false;
            }
        }
    }
}
