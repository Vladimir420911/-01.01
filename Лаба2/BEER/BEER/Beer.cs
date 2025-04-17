using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Beer
    {
        private string name_;
        private double price_;
        private type beertype_;


        public Beer(string n, double p, type bt)
        {
            name_ = n;
            price_ = p;
            beertype_ = bt;
        }

        public type GetBeerType()
        {
            return beertype_;
        }

        public double GetPrice() 
        {
            return price_;
        }
    }
}
