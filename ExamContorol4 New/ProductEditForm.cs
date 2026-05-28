using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamContorol4_New
{
    public partial class ProductEditForm : Form
    {

        int productId = 0;

        public ProductEditForm()
        {
            InitializeComponent();
        }

        public ProductEditForm(int prodId)
        {
            InitializeComponent();

            productId = prodId;
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
