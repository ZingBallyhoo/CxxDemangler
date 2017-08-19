﻿using System.Diagnostics;

namespace CxxDemangler.Parsers
{
    internal class Discriminator
    {
        public int Number { get; private set; }

        public static Discriminator Parse(ParsingContext context)
        {
            RewindState rewind = context.RewindState;

            if (!context.Parser.VerifyString("_"))
            {
                return null;
            }

            if (context.Parser.VerifyString("_"))
            {
                int number;

                if (context.Parser.ParseNumber(out number))
                {
                    Debug.Assert(number >= 0);
                    if (number >= 10 && context.Parser.VerifyString("_"))
                    {
                        return new Discriminator()
                        {
                            Number = number,
                        };
                    }
                }
                context.Rewind(rewind);
                return null;
            }

            if (char.IsDigit(context.Parser.Peek))
            {
                int number = context.Parser.Peek - '0';

                context.Parser.Position++;
                return new Discriminator()
                {
                    Number = number,
                };
            }

            context.Rewind(rewind);
            return null;
        }
    }
}
