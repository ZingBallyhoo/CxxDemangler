using CxxDemangler.Parsers;

namespace CxxDemangler
{
    public interface IParsingResult
    {
        void Demangle(DemanglingContext context);
    }

    public interface IParsingResultExtended : IParsingResult
    {
        TemplateArgs GetTemplateArgs();
    }
}
