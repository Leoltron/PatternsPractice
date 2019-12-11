namespace Xrm.ReportUtility.DataParsers.Providers
{
    public class XlsxDataParserBuilder : NoArgsDataParserBuilder<XlsxDataParser>
    {
        public override bool Matches(string filename) => filename.EndsWith(".xlsx");
    }
}
