using dotNetExt;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanNumerals
{
    public abstract class RomanNumber
    {
        // instance
        public abstract SymbolEnum Symbol { get; }
        public abstract int Value { get; }
        public string Alias { get; set; }

        protected virtual void ValidateRepeat(RomanCalculator connector)
        {
            if (connector.Contains($"{this.ToString()}{this.ToString()}{this.ToString()}{this.ToString()}"))
            {
                throw new Exception($"{this.Symbol} can not be repeated over than 3 times in successive.");
            }

            MatchCollection matches = null;
            if (connector.Contains(new Regex("^[" + this.ToString() + "]{3}([.]){1}" + this.ToString() + "$"), out matches))
            {
                var midNumber = RomanNumber.Create(matches[0].Value);
                if (midNumber.Value >= this.Value)
                {
                    throw new Exception($"{midNumber.Symbol} must be less than {this.ToString()}'s value : {this.ToString()}.");
                }
            }
        }
        protected virtual void ValidatePosition(RomanCalculator connector)
        {
            var afterNumbers = connector.After(this);
            if (!afterNumbers.IsNullOrEmpty() && !(afterNumbers.All(o => o.Value <= this.Value)))
            {
                throw new Exception($"{this.Symbol} can nerver be subtracted.");
            }
        }
        public virtual void Validate(RomanCalculator connector)
        {
            this.ValidateRepeat(connector);
            this.ValidatePosition(connector);
        }
        public override string ToString()
        {
            return this.Symbol.ToString();
        }

        // static
        public static RomanNumber Create(string symbol)
        {
            SymbolEnum type = (SymbolEnum)Enum.Parse(typeof(SymbolEnum), symbol);
            switch (type)
            {
                case SymbolEnum.I:
                    return I;
                case SymbolEnum.V:
                    return V;
                case SymbolEnum.X:
                    return X;
                case SymbolEnum.L:
                    return L;
                case SymbolEnum.C:
                    return C;
                case SymbolEnum.D:
                    return D;
                case SymbolEnum.M:
                    return M;
                default:
                    return null;
            }
        }

        public static RomanNumber I
        {
            get
            {
                return new I();
            }
        }

        public static RomanNumber V
        {
            get
            {
                return new V();
            }
        }

        public static RomanNumber X
        {
            get
            {
                return new X();
            }
        }

        public static RomanNumber L
        {
            get
            {
                return new L();
            }
        }

        public static RomanNumber C
        {
            get
            {
                return new C();
            }
        }

        public static RomanNumber D
        {
            get
            {
                return new D();
            }
        }

        public static RomanNumber M
        {
            get
            {
                return new M();
            }
        }

        public static string[] RomanNumbers
        {
            get
            {
                return new[]
                {
                    RomanNumber.I.ToString(),
                    RomanNumber.V.ToString(),
                    RomanNumber.X.ToString(),
                    RomanNumber.L.ToString(),
                    RomanNumber.C.ToString(),
                    RomanNumber.D.ToString(),
                    RomanNumber.M.ToString(),
                };
            }
        }
    }

    public class I : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.I;
            }
        }

        public override int Value
        {
            get
            {
                return 1;
            }
        }

        protected override void ValidatePosition(RomanCalculator connector)
        {
            var afterNumbers = connector.After(this);
            if (!afterNumbers.IsNullOrEmpty() && !(afterNumbers.All(o => o.Value <= this.Value || new[] { SymbolEnum.V, SymbolEnum.X }.Contains(o.Symbol))))
            {
                throw new Exception($"{this.Symbol} can be only subtracted from {SymbolEnum.V} {SymbolEnum.X}.");
            }
        }
    }

    public class V : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.V;
            }
        }

        public override int Value
        {
            get
            {
                return 5;
            }
        }

        protected override void ValidateRepeat(RomanCalculator connector)
        {
            if (connector.Contains($"{this.ToString()}{this.ToString()}"))
            {
                throw new Exception($"{this.ToString()} can nerver be repeated.");
            }
        }
    }

    public class X : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.X;
            }
        }

        public override int Value
        {
            get
            {
                return 10;
            }
        }

        protected override void ValidatePosition(RomanCalculator connector)
        {
            var afterNumbers = connector.After(this);
            if (!afterNumbers.IsNullOrEmpty() && !(afterNumbers.All(o => o.Value <= this.Value || new[] { SymbolEnum.L, SymbolEnum.C }.Contains(o.Symbol))))
            {
                throw new Exception($"{this.Symbol} can be only subtracted from {SymbolEnum.L} {SymbolEnum.C}.");
            }
        }
    }

    public class L : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.L;
            }
        }

        public override int Value
        {
            get
            {
                return 50;
            }
        }

        protected override void ValidateRepeat(RomanCalculator connector)
        {
            if (connector.Contains($"{this.ToString()}{this.ToString()}"))
            {
                throw new Exception($"{this.ToString()} can nerver be repeated.");
            }
        }
    }

    public class C : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.C;
            }
        }

        public override int Value
        {
            get
            {
                return 100;
            }
        }

        protected override void ValidatePosition(RomanCalculator connector)
        {
            var afterNumbers = connector.After(this);
            if (!afterNumbers.IsNullOrEmpty() && !(afterNumbers.All(o => o.Value <= this.Value || new[] { SymbolEnum.D, SymbolEnum.M }.Contains(o.Symbol))))
            {
                throw new Exception($"{this.Symbol} can be only subtracted from {SymbolEnum.D} {SymbolEnum.M}.");
            }
        }
    }

    public class D : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.D;
            }
        }

        public override int Value
        {
            get
            {
                return 500;
            }
        }

        protected override void ValidateRepeat(RomanCalculator connector)
        {
            if (connector.Contains($"{this.ToString()}{this.ToString()}"))
            {
                throw new Exception($"{this.ToString()} can nerver be repeated.");
            }
        }
    }

    public class M : RomanNumber
    {
        public override SymbolEnum Symbol
        {
            get
            {
                return SymbolEnum.M;
            }
        }

        public override int Value
        {
            get
            {
                return 1000;
            }
        }

        protected override void ValidatePosition(RomanCalculator connector)
        {
            var beforeNumbers = connector.Before(this);
            if (!beforeNumbers.IsNullOrEmpty() && !(beforeNumbers.All(o => o.Value >= this.Value || new[] { SymbolEnum.C }.Contains(o.Symbol))))
            {
                throw new Exception($"{this.Symbol} can be only subtracted from {SymbolEnum.C}.");
            }
        }
    }
}
