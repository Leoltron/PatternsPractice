namespace Xrm.ReportUtility.DataParsers.Providers
{
    public class TxtDataParserBuilder : NoArgsDataParserBuilder<TxtDataParser>
    {
        public override bool Matches(string filename) => filename.EndsWith(".txt");
    }
}
