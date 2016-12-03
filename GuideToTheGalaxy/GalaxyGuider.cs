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

namespace GuideToTheGalaxy
{
    public static class GalaxyGuider
    {
        private static GuideResponse Solve(string content)
        {
            content = content?.Trim();
            if (content.IsNullOrWhiteSpace())
            {
                return GuideResponse.Empty;
            }

            var splitedDesc = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            try
            {
                if (splitedDesc.Count == 3 && RomanNumber.RomanNumbers.Contains(splitedDesc.Last()))
                {
                    DirectiveProxy<AliasCommandDirective>.Create(content).Command.Execute()?.ToString();
                    return GuideResponse.Empty;
                }

                if (splitedDesc.Last().Equals("Credits", StringComparison.InvariantCultureIgnoreCase))
                {
                    DirectiveProxy<UnitPriceCommandDirective>.Create(content).Command.Execute()?.ToString();
                    return GuideResponse.Empty;
                }

                if (content.StartsWith("how much", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new GuideResponse()
                    {
                        Message = DirectiveProxy<HowMuchCommandDirective>.Create(content).Command.Execute()?.ToString()
                    };
                }


                if (content.StartsWith("how many", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new GuideResponse()
                    {
                        Message = DirectiveProxy<HowManyCommandDirective>.Create(content).Command.Execute()?.ToString()
                    };
                }

            }
            catch
            {
            }

            return new GuideResponse()
            {
                Message = DirectiveProxy<UnknownCommandDirective>.Create(content).Command.Execute()?.ToString()
            };
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
