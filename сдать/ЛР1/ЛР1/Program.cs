using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DishInfo> dishes = new List<DishInfo>()
            {
                new DishInfo("Борщ", "суп", 1, 12),
                new DishInfo("Щи", "суп", 2, 18),
                new DishInfo("Гороховый суп", "суп", 2, 26),
                new DishInfo("Сок апельсиновый", "напиток", 2, 12),
                new DishInfo("Черный чай", "напиток", 2, 28),
            };

            Console.WriteLine("Введите название категории: ");
            string category = Console.ReadLine();

            List<DishInfo> sortedDishes = FindByCategory(dishes, category);
            var popularDishes = sortedDishes.OrderByDescending(d => d.Amount).ToList();

            foreach(var dish in popularDishes)
            {
                Console.WriteLine($"Наименование блюда: {dish.DishName}, кол-во заказов: {dish.Amount}");
            }

            double avgOrdersCount = sortedDishes.Average(d => d.Amount);
            Console.WriteLine($"Среднее количество продаж по данной категории = {avgOrdersCount}");
        }

        static List<DishInfo> FindByCategory(List<DishInfo> dishInfos, string category)
        {
            List<DishInfo> sortedList = new List<DishInfo>();

            foreach(var dish in dishInfos)
            {
                if(dish.DishCategory == category)
                {
                    sortedList.Add(dish);
                }
            }

            return sortedList;
        }


    }
}
