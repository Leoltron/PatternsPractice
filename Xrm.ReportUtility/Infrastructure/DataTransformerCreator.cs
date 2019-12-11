using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        /**
         * Идея - каждого наследника ReportServiceTransformerBase обернуть в свой фабричный метод, причем каждый
         * класс - фабрика будет дополнительно реализовывать Matches(ReportConfig config)
         * помимо Build(IDataTransformer dt), подобно тому, как сейчас выбирается IDataParser,
         * только вместо выбора первого попавшегося цепочка строится из всех подошедших с DataTransformer в начале.
         */
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            IDataTransformer service = new DataTransformer(config);

            if (config.WithData)
            {
                service = new WithDataReportTransformer(service);
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}