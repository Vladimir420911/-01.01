using ClassLib;
using ClassLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTreeView
{
    public partial class MainForm: Form
    {
        private List<TreeNodeModel> treeData_;
        private TreeNodeChildModel childModel;
        public MainForm()
        {
            InitializeComponent();
            treeData_ = new List<TreeNodeModel>();
            childModel = new TreeNodeChildModel();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            {
                treeData_.Add(new TreeNodeModel("Оникс"));
                var restNode = treeData_[0];
                var salad = restNode.AddChildNode("Салаты");
                salad.AddChildNode("Цезарь");
                salad.AddChildNode("Не цезарь");
                salad.AddChildNode("Почти цезарь");

                var beverage = restNode.AddChildNode("Напитки");
                beverage.AddChildNode("Вода");
                beverage.AddChildNode("Пиво");
                beverage.AddChildNode("Воды мало не бывает");

                var soup = restNode.AddChildNode("Супы");
                soup.AddChildNode("Уха");
                soup.AddChildNode("Борщ");
                soup.AddChildNode("Щи");
            }

            FillTreeNodeCollection(treeData_, treeView1.Nodes);
            treeView1.ExpandAll();

            dataGridView1.Columns.Add("Name", "Наименование");
            dataGridView1.Columns.Add("Description", "Описание");
            dataGridView1.Columns.Add("Price", "Цена");
        }

        static private void FillTreeNodeCollection(List<TreeNodeModel> sourceData,
                                                   TreeNodeCollection targetData)
        {
            foreach (var node in sourceData)
            {
                var treeNode = new TreeNode(node.Name);
                targetData.Add(treeNode);

                if (node.Children != null && node.Children.Count > 0)
                {
                    FillTreeNodeCollection(node.Children, treeNode.Nodes);
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Nodes.Count == 0)
            {
                TreeNodeChild Ch = childModel.GetName(e.Node.Text);
                if(Ch != null)
                {
                    object[] newRow = { Ch.Name, Ch.Description, Ch.Price };
                    dataGridView1.Rows.Add(newRow);
                }
            }
        }
    }
}
