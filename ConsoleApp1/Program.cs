using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> list = new List<int>() {-3, 1, 3, 5, 8, 10, 12};

                foreach (int i in list)
                {
                    Console.WriteLine("Список = "+i);
                }

                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i]%5 == 0 ) 
                    { 
                    list.RemoveAt(i);
                    }
                
                }

            foreach (int i in list)
            {
                Console.WriteLine("Список после удаления= = " + i);
            }





            Console.ReadKey();
            
            
        }
    }
}
