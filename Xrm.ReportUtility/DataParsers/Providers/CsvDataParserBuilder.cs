namespace Xrm.ReportUtility.DataParsers.Providers
{
    public class CsvDataParserBuilder : NoArgsDataParserBuilder<CsvDataParser>
    {
        public override bool Matches(string filename) => filename.EndsWith(".csv");
    }
}
