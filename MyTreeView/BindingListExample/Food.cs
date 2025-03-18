using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingListExample
{
    class Food
    {
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Price { get; set; }

        public Food(string name, DateTime expireDate, int price)
        {
            Name = name;
            ExpireDate = expireDate;
            Price = price;
        }
    }
}
