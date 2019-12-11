using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IConfigParser
    {
        bool TryParseConfig(string[] args, out ReportConfig reportConfig);
    }
}
