﻿using GuideToTheGalaxy.Core;
using RomanNumerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Commands
{
    public class AliasCommand : Command<AliasCommandDirective>
    {
        public AliasCommand(AliasCommandDirective directive) : base(directive)
        {
        }

        protected static readonly List<RomanNumber> AliasNumbers = new List<RomanNumber>();

        public override object Execute()
        {
            var existsRomanNumber = AliasCommand.AliasNumbers.FirstOrDefault(o => o.Symbol.Equals(this._directive.Number.Symbol));
            if (existsRomanNumber != null)
            {
                existsRomanNumber.Alias = this._directive.Number.Alias;
            }
            else
            {
                AliasCommand.AliasNumbers.Add(this._directive.Number);
            }

            return this._directive.Number;
        }

        public static void Clear()
        {
            AliasCommand.AliasNumbers.Clear();
        }

        public static RomanNumber GetRomanNumberByAlias(string alias)
        {
            return AliasCommand.AliasNumbers.FirstOrDefault(o => o.Alias.Equals(alias?.Trim(), StringComparison.InvariantCultureIgnoreCase));
        }

        public static List<RomanNumber> GetAllRomainNumbers()
        {
            return AliasNumbers;
        }
    }

    public class AliasCommandDirective : CommandDirective<AliasCommand>
    {
        public AliasCommandDirective(string content) :
        base(content)
        {
        }

        public string Alias
        {
            get
            {
                return this.Content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
        }

        public string Symbol
        {
            get
            {
                return this.Content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]?.ToUpper().Trim();
            }
        }

        public RomanNumber Number
        {
            get
            {
                var roman = RomanNumber.Create(this.Symbol);
                if (roman != null)
                {
                    roman.Alias = this.Alias;
                }

                return roman;
            }
        }

        public override AliasCommand Command
        {
            get
            {
                return new AliasCommand(this);
            }
        }
    }
}
