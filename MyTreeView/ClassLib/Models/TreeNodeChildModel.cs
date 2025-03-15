using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Models
{
    public class TreeNodeChildModel
    {
        public List<TreeNodeChild> Children { get; }

        public TreeNodeChildModel()
        {
            Children = new List<TreeNodeChild>
            {
                new TreeNodeChild { Name = "Цезарь", Description = "Это цезарь", Price = 45 },
                new TreeNodeChild { Name = "Не цезарь", Description = "Это не цезарь", Price = 55 },
                new TreeNodeChild { Name = "Почти цезарь", Description = "Это почти цезарь", Price = 35 },
                new TreeNodeChild { Name = "Вода", Description = "Это не пиво", Price = 45 },
                new TreeNodeChild { Name = "Пиво", Description = "Это не вода", Price = 55 },
                new TreeNodeChild { Name = "Воды мало не бывает", Description = "Это вода(ее много)", Price = 35 },
                new TreeNodeChild { Name = "Уха", Description = "УХАХАХА", Price = 45 },
                new TreeNodeChild { Name = "Борщ", Description = "nom nom nom", Price = 55 },
                new TreeNodeChild { Name = "Щи", Description = "ААААААААААА", Price = 35 }
            };
        }
           
        

        public TreeNodeChild GetName(string Name)
        {
            return Children.Find(e => e.Name == Name);
        }
    }
}
