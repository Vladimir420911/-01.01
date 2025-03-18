using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingListExample
{
    public partial class EditForm: Form
    {
        BindingList<Food> _bind;
        internal EditForm(BindingList<Food> b)
        {
            InitializeComponent();
            _bind = b;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var food = new Food(nameTextBox.Text, expireDatePicker.Value, Convert.ToInt32(priceUpDown.Value));

            _bind.Add(food);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
