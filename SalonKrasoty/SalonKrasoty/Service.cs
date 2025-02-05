using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasoty
{
    public class Service
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> Masters { get; set; }

        public Service(string name, decimal price, List<string> masters)
        {
            Name = name;
            Price = price;
            Masters = masters;
        }
        public new string ToString()
        {
            return $"{Name};{Price};{string.Join(",", Masters)}";
        }
        public static Service Parse(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length != 3) throw new FormatException("Неправильный формат строки услуги");

            return new Service(parts[0], decimal.Parse(parts[1], CultureInfo.InvariantCulture), parts[2].Split(',').ToList());
        }
    }
}
