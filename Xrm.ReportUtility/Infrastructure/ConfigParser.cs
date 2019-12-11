using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public class ConfigParser : IConfigParser
    {
        public bool TryParseConfig(string[] args, out ReportConfig reportConfig)
        {
            reportConfig = ParseConfig(args);
            return true;
        }

        private static ReportConfig ParseConfig(string[] args)
        {
            return new ReportConfig
            {
                SourceFile = args[0],
                
                WithData = args.Contains("-data"),

                WithIndex = args.Contains("-withIndex"),
                WithTotalVolume = args.Contains("-withTotalVolume"),
                WithTotalWeight = args.Contains("-withTotalWeight"),

                VolumeSum = args.Contains("-volumeSum"),
                WeightSum = args.Contains("-weightSum"),
                CostSum = args.Contains("-costSum"),
                CountSum = args.Contains("-countSum")
            };
        }
    }
}
