using System;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = new ReportService(new ConfigParser());

            var report = service.CreateReport(args);

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        /**
         * Идея - вынести печать результата работы трансформатора в сам трансформатор, таким образом, при добавлении
         * очередного трансформатора данных, достаточно будет реализовать интерфейс и добавить его в создание
         * цепочки - улучшение реализации декоратора.
         */
        private static void PrintReport(Report report)
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                var headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество";
                var rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";

                if (report.Config.WithIndex)
                {
                    headerRow = "№\t" + headerRow;
                    rowTemplate = "{0}\t" + rowTemplate;
                }

                if (report.Config.WithTotalVolume)
                {
                    headerRow += "\tСуммарный объём";
                    rowTemplate += "\t{6,15}";
                }

                if (report.Config.WithTotalWeight)
                {
                    headerRow += "\tСуммарный вес";
                    rowTemplate += "\t{7,13}";
                }

                Console.WriteLine(headerRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost,
                                      dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine($"  {reportRow.Name,-20}\t{reportRow.Value}");
                }
            }
        }
    }
}
