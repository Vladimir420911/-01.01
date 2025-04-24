using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sales_history = new SalesHistory();
            sales_history.AddSale(new Beer("Жигулевское", 149.99, type.alc), 10, 1);
            sales_history.AddSale(new Beer("Жигулевское", 149.99, type.alc), 6, 2);
            sales_history.AddSale(new Beer("Балтика 0", 119.99, type.nonalc), 5, 1);
            sales_history.AddSale(new Beer("Балтика 0", 119.99, type.nonalc), 7, 2);
            sales_history.AddSale(new Beer("Клинское", 169.99, type.alc), 15, 1);
            sales_history.AddSale(new Beer("Клинское", 169.99, type.alc), 6, 2);
            sales_history.AddSale(new Beer("Сибирская корона", 199.99, type.alc), 8, 1);
            sales_history.AddSale(new Beer("Сибирская корона", 199.99, type.alc), 10, 2);
            sales_history.AddSale(new Beer("Безалкогольное пиво ", 99.99, type.nonalc), 12, 1);
            sales_history.AddSale(new Beer("Безалкогольное пиво ", 99.99, type.nonalc), 15, 2);

            var salesReport = sales_history.GenerateSalesReportByDay();

            Console.WriteLine("Отчет по продажам:");
            foreach (var daySales in salesReport)
            {
                Console.WriteLine($"День {daySales.Key:d}:");
                Console.WriteLine($"  Алкогольное пиво: {daySales.Value[type.alc]}");
                Console.WriteLine($"  Безалкогольное пиво: {daySales.Value[type.nonalc]}");
                Console.WriteLine($"  Общая выручка за день: {daySales.Value[type.alc] + daySales.Value[type.nonalc]}");
            }
            Console.ReadKey();
        }
    }
}
