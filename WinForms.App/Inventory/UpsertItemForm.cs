using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.App
{
    public partial class UpsertItemForm : Form
    {
        public UpsertItemForm()
        {
            InitializeComponent();

        }

        private void Button3_Click_2(object sender, EventArgs e) => Close();

        private void Button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(Text, "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Service.InventoryManager.Items.Add(new Service.Item
            {
                Name = textBox1.Text,
                Code = textBox2.Text,
                Price = decimal.Parse(textBox3.Text),
                Description = textBox4.Text
            });

            this.Close();
        }
    }
}
