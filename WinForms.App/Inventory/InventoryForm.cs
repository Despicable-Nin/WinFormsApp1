using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Service;

namespace WinForms.App
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var upsertItemForm = new UpsertItemForm();
            upsertItemForm.Name = "UpsertItemForm";
            upsertItemForm.ShowDialog(this);

            ResetDataGridView();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var items = Service.InventoryManager.Items;
            var filteredList = items.Where(i => i.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) || i.Code.Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToArray();

            ResetDataGridView(filteredList);

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            ResetDataGridView();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
                column.Width = 100; // Adjust as needed
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check for valid row index
            if (e.RowIndex >= 0 && e.RowIndex < Service.InventoryManager.Items.Count)
            {
                var selectedItem = Service.InventoryManager.Items.ToArray()[e.RowIndex];
                // ... (your logic to handle the selected item)
            }
            else
            {
                // Handle invalid index (e.g., show an error message)
                MessageBox.Show("Invalid row index.");
            }
        }

        private void ResetDataGridView(IEnumerable<Item>? items = null)
        {
            if(items == null)
            {
                items = Service.InventoryManager.Items;
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = items;
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Refresh();
        }
    }
}
