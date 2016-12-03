using dotNetExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanNumerals
{
    public class RomanCalculator : List<RomanNumber>
    {
        public int Value
        {
            get
            {
                if (this.IsNullOrEmpty())
                {
                    return 0;
                }
                else
                {
                    this.Validate();
                    int result = 0;
                    for (int i = 0; i < this.Count; i++)
                    {
                        var current = i;
                        var next = i + 1;
                        if (next >= this.Count)
                        {
                            result += this[current].Value;
                        }
                        else
                        {
                            if (this[current].Value >= this[next].Value)
                            {
                                result += this[current].Value;
                            }
                            else
                            {
                                result += this[next].Value - this[current].Value;
                                i += 1;
                            }
                        }
                    }

                    return result;
                }
            }
        }

        private int GetSubtractCount()
        {
            var types = new[] {
              $"{SymbolEnum.I}{SymbolEnum.V}"
            , $"{SymbolEnum.I}{SymbolEnum.X}"
            , $"{SymbolEnum.X}{SymbolEnum.L}"
            , $"{SymbolEnum.X}{SymbolEnum.C}"
            , $"{SymbolEnum.C}{SymbolEnum.D}"
            , $"{SymbolEnum.C}{SymbolEnum.M}"};
            int count = 0;
            foreach (var item in types)
            {
                count += this.ToString().Split(new[] { item }, StringSplitOptions.None).Length - 1;
            }

            return count;
        }

        private void Validate()
        {
            this.ForEach(o => o.Validate(this));
            if (this.GetSubtractCount() > 1)
            {
                throw new Exception("Only one small-value symbol may be subtracted from any large-value symbol.");
            }
        }

        public bool Contains(string symbols)
        {
            return this.ToString().Contains(symbols?.Trim());
        }

        public bool Contains(Regex regex, out MatchCollection matches)
        {
            matches = null;
            if (regex.IsMatch(this.ToString()))
            {
                matches = regex.Matches(this.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RomanNumber> After(RomanNumber current)
        {
            if (this.Contains(current.Symbol.ToString()))
            {
                var startIndex = this.IndexOf(this.FirstOrDefault(o => o.Symbol == current.Symbol)) + 1;
                return startIndex >= this.Count ? null : this.GetRange(startIndex, this.Count - startIndex);
            }
            else
            {
                return null;
            }
        }

        public List<RomanNumber> Before(RomanNumber current)
        {
            if (this.Contains(current.Symbol.ToString()))
            {
                var startIndex = this.IndexOf(this.LastOrDefault(o => o.Symbol == current.Symbol)) - 1;
                return startIndex < 0 ? null : this.GetRange(0, startIndex + 1);
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            if (this.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else
            {
                return string.Join(string.Empty, this.Select(o => o.Symbol.ToString()));
            }
        }
    }
}
