using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingListExample
{
    public partial class Form1: Form
    {
        BindingList<Food> bind = new BindingList<Food>();
        public Form1()
        {

            InitializeComponent();
            bind = new BindingList<Food>
            {
                new Food("Огурец", new DateTime(2025, 10, 05), 100),
                new Food("Помидор", new DateTime(2025, 05, 05), 75)
            };

            dataGridView1.DataSource = bind;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var EditForm = new EditForm(bind);
            EditForm.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
    }
}
