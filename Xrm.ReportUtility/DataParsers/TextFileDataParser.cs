using System.IO;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.DataParsers
{
    public abstract class TextFileDataParser : IDataParser
    {
        public DataRow[] GetDataRows(string filename)
        {
            return GetDataRowsFromText(File.ReadAllText(filename));
        }

        protected abstract DataRow[] GetDataRowsFromText(string text);
    }
}
