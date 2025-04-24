using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Beer
    {
        public string Name;
        public double Price;
        public type BeerType;


        public Beer(string n, double p, type bt)
        {
            Name = n;
            Price = p;
            BeerType = bt;
        }
    }
}
