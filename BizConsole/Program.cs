using GuideToTheGalaxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetExt;

namespace BizConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var responses = GalaxyGuider.SolveFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.txt"));
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

            Console.ReadKey();
        }
    }
}
