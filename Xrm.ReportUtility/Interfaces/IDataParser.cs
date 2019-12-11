using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IDataParser
    {
        DataRow[] GetDataRows(string filename);
    }
}
