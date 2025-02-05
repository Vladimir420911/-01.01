using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasoty
{
    public class Client
    {
        public string Name { get; set; }

        public Client(string name)
        {
            Name = name;
        }

        public new string ToString()
        {
            return Name;
        }
    }
}
