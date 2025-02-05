using BEER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sales_history = new sales_history();
            sales_history.AddSale(new Beer("Жигулевское", 150, type.alc), 10, "День 1");
            sales_history.AddSale(new Beer("Жигулевское", 150, type.alc), 6, "День 2");
            sales_history.AddSale(new Beer("Балтика 0", 120, type.nonalc), 5, "День 1");
            sales_history.AddSale(new Beer("Балтика 0", 120, type.nonalc), 7, "День 2");
            sales_history.AddSale(new Beer("Клинское", 170, type.alc), 15, "День 1");
            sales_history.AddSale(new Beer("Клинское", 170, type.alc), 6, "День 2");
            sales_history.AddSale(new Beer("Сибирская корона", 200, type.alc), 8, "День 1");
            sales_history.AddSale(new Beer("Сибирская корона", 200, type.alc), 10, "День 2");
            sales_history.AddSale(new Beer("Безалкогольное пиво ", 100, type.nonalc), 12, "День 1");
            sales_history.AddSale(new Beer("Безалкогольное пиво ", 100, type.nonalc), 15, "День 2");

            var salesReport = sales_history.GenerateSalesReportByDay();

            Console.WriteLine("Отчет по продажам:");
            foreach (var daySales in salesReport)
            {
                Console.WriteLine($"\n{daySales.Key:d}:");
                Console.WriteLine($"  Алкогольное пиво: {daySales.Value[type.alc]}");
                Console.WriteLine($"  Безалкогольное пиво: {daySales.Value[type.nonalc]}");
                Console.WriteLine($"  Общая выручка за день: {daySales.Value[type.alc] + daySales.Value[type.nonalc]}");
                /*
                Console.WriteLine($"Алкогольное пиво: {salesReport[type.alc]}руб.");
                Console.WriteLine($"Безалкогольное пиво: {salesReport[type.nonalc]}руб.");
                Console.WriteLine($"Общая выручка: {salesReport[type.alc] + salesReport[type.nonalc]}руб.");
                */
                Console.ReadKey();
            }
        }
    }
}
