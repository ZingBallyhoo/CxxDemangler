using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CxxDemangler.Tests.Parsing
{
    [TestClass]
    public class BareFunctionType : TestBase
    {
        [TestMethod]
        public void BareFunctionType1()
        {
            Verify("S_S_...",
                new Parsers.BareFunctionType(
                    new[]
                    {
                        new Parsers.Substitution(0),
                        new Parsers.Substitution(0),
                    }));
        }

        [TestMethod]
        public void BareFunctionTypeFailures()
        {
            Assert.IsNull(Parse(""));
        }

        public override IEnumerable<IParsingResult> SubstitutionTableList()
        {
            yield return new Parsers.StandardBuiltinType(Parsers.StandardBuiltinType.Values.Char);
        }

        public override IParsingResult Parse(ParsingContext context)
        {
            return Parsers.BareFunctionType.Parse(context);
        }
    }
}
