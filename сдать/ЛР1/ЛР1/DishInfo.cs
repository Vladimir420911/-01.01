using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    public struct DishInfo
    {
        public string DishName;
        public string DishCategory;
        public int DayOfOrder;
        public int Amount;

        public DishInfo(string dishInfo, string dishCategory, int dayOfOrder, int amount)
        {
            DishName = dishInfo;
            DishCategory = dishCategory;
            DayOfOrder = dayOfOrder;
            Amount = amount;
        }
    }
}
