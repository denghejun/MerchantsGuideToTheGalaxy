using GuideToTheGalaxy.Models;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetExt;
using GuideToTheGalaxy.Core;
using GuideToTheGalaxy.Commands;
using System.IO;
using GuideToTheGalaxy.Strategies;

namespace GuideToTheGalaxy
{
    public static class GalaxyGuider
    {
        private static readonly ICommandStrategy[] CommandStrategies = new ICommandStrategy[]
        {
            new AliasCommandStrategy(),
            new UnitPriceCommandStrategy(),
            new HowMuchCommandStrategy(),
            new HowManyCommandStrategy(),
            new UnknownCommandStrategy()
        };

        private static GuideResponse Solve(string content)
        {
            try
            {
                return CommandStrategies.FirstOrDefault(o => o.CanExecute(content))?.Execute(content) ?? GuideResponse.Unknown;
            }
            catch
            {
                return GuideResponse.Unknown;
            }
        }

        private static GuideResponse[] Solve(string[] contents)
        {
            return contents?.Select(o => Solve(o)).ToArray();
        }

        public static GuideResponse[] SolveFromFile(string path)
        {
            return File.Exists(path) ? Solve(File.ReadAllLines(path)) : new[] { new GuideResponse($"{path} NOT exists.") };
        }
    }
}
