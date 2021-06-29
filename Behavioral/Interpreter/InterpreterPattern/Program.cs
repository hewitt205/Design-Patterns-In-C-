using System;
using System.Diagnostics;

namespace InterpreterPattern
{
    class Program
    {
        const string ONE = "I";
        const string TWO = "II";
        const string THREE = "III";
        const string FOUR = "IV";
        const string FIVE = "V";
        const string NINE = "IX";

        const string TEN = "X";
        const string TWENTY = "XX";
        const string THIRTY = "XXX";
        const string FOURTY = "XL";
        const string FIFTY = "L";
        const string NINETY = "XC";

        public class RomanNumberals
        {
            public int Input { get; set; }
            public string Output { get; set; }

            public RomanNumberals(int baseTenNumber)
            {
                Input = baseTenNumber;
            }
        }

        public abstract class Expression
        {
            public abstract void Interpret(RomanNumberals baseTenNumber);
        }

        public class RomanOneExpression : Expression
        {
            public override void Interpret(RomanNumberals baseTenNumber)
            {
                while((baseTenNumber.Input -9) >= 0)
                {
                    baseTenNumber.Output += NINE;
                    baseTenNumber. -= 9;
                }
                while((baseTenNumber.Input -5) >= 0)
                {
                    baseTenNumber.Output += FIVE;
                    baseTenNumber. -= 5;
                }
                while((baseTenNumber.Input -4) >= 0)
                {
                    baseTenNumber.Output += FOUR;
                    baseTenNumber. -= 4;
                }
                while((baseTenNumber.Input -3) >= 0)
                {
                    baseTenNumber.Output += THREE;
                    baseTenNumber. -= 3;
                }
                while((baseTenNumber.Input -2) >= 0)
                {
                    baseTenNumber.Output += TWO;
                    baseTenNumber. -= 2;
                }
                while((baseTenNumber.Input -1) >= 0)
                {
                    baseTenNumber.Output += ONE;
                    baseTenNumber. -= 1;
                }
            }
        }

        public class RomanTenExpression : Expression
        {
            public override void Interpret(RomanNumberals baseTenNumber)
            {
                while((baseTenNumber.Input - 90) >= 0)
                {
                    baseTenNumber.Output += NINETY;
                    baseTenNumber.Input -= 90;
                }
                while((baseTenNumber.Input - 50) >= 0)
                {
                    baseTenNumber.Output += FIFTY;
                    baseTenNumber.Input -= 50;
                }
                while((baseTenNumber.Input - 40) >= 0)
                {
                    baseTenNumber.Output += FOURTY;
                    baseTenNumber.Input -= 40;
                }
                while((baseTenNumber.Input - 30) >= 0)
                {
                    baseTenNumber.Output += THIRTY;
                    baseTenNumber.Input -= 30;
                }
                while((baseTenNumber.Input - 20) >= 0)
                {
                    baseTenNumber.Output += TWENTY;
                    baseTenNumber.Input -= 20;
                }
                while((baseTenNumber.Input - 10) >= 0)
                {
                    baseTenNumber.Output += TEN;
                    baseTenNumber.Input -= 10;
                }
            }
        }

        static void Main(string[] args)
        {
            Expression[] expressions = new Expression[]
            {
                new RomanTenExpression(),
                new RomanOneExpression()
            };

            var context = new RomanNumberals(56);

            foreach(var expression in expressions)
            {
                expression.Interpret(context);
            }

            Debug.WriteLine(context.Output);
        }
    }
}
