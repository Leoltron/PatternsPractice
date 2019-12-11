using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    /**
     * Наследники этого класса - реализация Decorator,
     * т.к. добавляют трансформации (по сути - способы агрегации) данных поверх сущесвтующих
     */
    public abstract class ReportServiceTransformerBase : IDataTransformer
    {
        protected readonly IDataTransformer DataTransformer;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data);
    }
}
