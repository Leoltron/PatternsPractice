using System;
using System.Linq;
using Xrm.ReportUtility.DataParsers.Providers;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataParserProvider
    {
        private static readonly IDataParserBuilder[] Builders =
        {
            new CsvDataParserBuilder(),
            new TxtDataParserBuilder(),
            new XlsxDataParserBuilder()
        };

        /*
         * Статический фабричный метод, по сути, является переделкой Program.GetReportService()
         */
        public static IDataParser Provide(string filename)
        {
            return Builders.FirstOrDefault(b => b.Matches(filename))?.Build() ??
                   throw new NotSupportedException("this extension not supported");
        }
    }
}
