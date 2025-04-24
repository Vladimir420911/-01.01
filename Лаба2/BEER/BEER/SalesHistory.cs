using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class SalesHistory
    {
        private List<Sale> sales = new List<Sale>();

        public void AddSale(Beer Beer, int Quantity, int Day)
        {
            sales.Add(new Sale(Beer, Quantity, Day));
        }

        public Dictionary<int, Dictionary<type, double>> GenerateSalesReportByDay()
        {
            var report = new Dictionary<int, Dictionary<type, double>>();

            foreach (var sale in sales)
            {
                if (!report.ContainsKey(sale.Day))
                {
                    report[sale.Day] = new Dictionary<type, double>();
                    report[sale.Day][type.alc] = 0;
                    report[sale.Day][type.nonalc] = 0;
                }
                report[sale.Day][sale.Beer.GetBeerType()] += sale.Beer.GetPrice() * sale.Quantity;
            }
            return report;
        }
    }
}
