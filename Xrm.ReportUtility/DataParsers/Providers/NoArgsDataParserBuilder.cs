using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.DataParsers.Providers
{
    public abstract class NoArgsDataParserBuilder<T> : IDataParserBuilder where T : IDataParser, new()
    {
        public abstract bool Matches(string filename);

        public IDataParser Build() => new T();
    }
}
