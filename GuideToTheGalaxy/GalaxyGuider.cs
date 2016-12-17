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
        private static readonly List<ICommandStrategy> CommandStrategies = new List<ICommandStrategy>()
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
                return CommandStrategies.FirstOrDefault(o => o.CanExecute(content))?.Execute(content) ?? GuideResponse.Empty;
            }
            catch
            {
                return GuideResponse.Empty;
            }
        }

        private static List<GuideResponse> Solve(List<string> contents)
        {
            return contents?.Select(o => Solve(o)).ToList();
        }

        public static List<GuideResponse> SolveFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return new List<GuideResponse>()
                {
                    new GuideResponse($"{path} NOT exists.")
                };
            };

            var contentLines = File.ReadLines(path);
            return Solve(contentLines?.ToList());
        }
    }
}
