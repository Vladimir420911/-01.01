using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Models
{
    public class TreeNodeModel
    {
        public string Name { get; set; }

        public List<TreeNodeModel> Children { get; }

        public TreeNodeModel(string name)
        {
            Name = name;
            Children = new List<TreeNodeModel>();
        }

        public TreeNodeModel AddChildNode(string text)
        {
            TreeNodeModel node = new TreeNodeModel(text);
            Children.Add(node);

            return node;
        }
    }
}
