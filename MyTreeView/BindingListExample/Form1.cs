using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }
        
    }
}
