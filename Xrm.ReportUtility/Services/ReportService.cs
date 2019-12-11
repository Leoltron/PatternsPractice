using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    /**
     * Была идея сделать IDataParser полем ReportService и реализовать шаблон Bridge, но ReportService не имеет
     * собственной иерархии на данный момент
     */
    public class ReportService
    {
        /**
         * Идея - новый парсер - цепочка ответственности для реализации отдельных фильтров проверки:
         * один ищет в аргументах флаги для агрегирующих функций, другой ищет флаги, убирающие столбцы
         * «Объём упаковки», «Масса упаковки», «Стоимость», «Количество», третий проверяет обязательные флаги
         * (Уже реализован функционал неудачного парсинга аргументов), четветрый може твыполнять легенту-хотелку
         *      "В случае, когда указан один из флагов «withIndex»,
         *         «withTotalVolume», «withTotalWeight», но не указан «data» -
         *          выводить warning (жёлтым цветом)"
         */
        private readonly IConfigParser configParser;

        public ReportService(IConfigParser configParser)
        {
            this.configParser = configParser;
        }

        public Report CreateReport(string[] args)
        {
            if (!configParser.TryParseConfig(args, out var config))
                return null;

            var dataParser = DataParserProvider.Provide(config.SourceFile);
            var data = dataParser.GetDataRows(config.SourceFile);

            var dataTransformer = DataTransformerCreator.CreateTransformer(config);
            return dataTransformer.TransformData(data);
        }
    }
}
