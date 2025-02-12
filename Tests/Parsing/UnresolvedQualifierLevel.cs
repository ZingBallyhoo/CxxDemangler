﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CxxDemangler.Tests.Parsing
{
    [TestClass]
    public class UnresolvedQualifierLevel : TestBase
    {
        [TestMethod]
        public void UnresolvedQualifierLevelSimpleId()
        {
            Verify("3abc...",
                new Parsers.SimpleId(
                    new Parsers.SourceName.Identifier("abc"),
                    arguments: null));
        }

        [TestMethod]
        public void UnresolvedQualifierLevelSimpleIdTemplateArgs()
        {
            Verify("3abcIS_E...",
                new Parsers.SimpleId(
                    new Parsers.SourceName.Identifier("abc"),
                    new Parsers.TemplateArgs(
                        new[]
                        {
                            new Parsers.Substitution(0),
                        })));
        }

        [TestMethod]
        public void UnresolvedQualifierLevelFailures()
        {
            Assert.IsNull(Parse("zzz"));
            Assert.IsNull(Parse(""));
        }

        public override IEnumerable<IParsingResult> SubstitutionTableList()
        {
            yield return new Parsers.Expression.Retrow();
        }

        public override IParsingResult Parse(ParsingContext context)
        {
            return Parsers.UnresolvedQualifierLevel.Parse(context);
        }
    }
}
