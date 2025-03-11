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
            Children = new List<TreeNodeChild>();
            Children.Add
            (
                new TreeNodeChild { Name = "Цезарь", Description = "Это цезарь", Price = 45 }
            );
            Children.Add
            (
                new TreeNodeChild { Name = "Не цезарь", Description = "Это не цезарь", Price = 55 }
            );
            Children.Add
            (
                new TreeNodeChild { Name = "Почти цезарь", Description = "Это почти цезарь", Price = 35 }
            );
        }
           
        

        public TreeNodeChild GetName(string Name)
        {
            return Children.Find(e => e.Name == Name);
        }
    }
}
