using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Beer
    {
        public string name_;
        public double price_;
        public type beertype_;


        public Beer(string n, double p, type bt)
        {
            name_ = n;
            price_ = p;
            beertype_ = bt;
        }
    }
}
