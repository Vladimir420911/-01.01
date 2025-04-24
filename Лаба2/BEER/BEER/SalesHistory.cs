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
                if (!report.ContainsKey(sale.GetDay()))
                {
                    report[sale.GetDay()] = new Dictionary<type, double>();
                    report[sale.GetDay()][type.alc] = 0;
                    report[sale.GetDay()][type.nonalc] = 0;
                }
                report[sale.GetDay()][sale.GetBeer().BeerType] += sale.GetBeer().Price * sale.GetQuantity();
            }
            return report;
        }
    }
}
