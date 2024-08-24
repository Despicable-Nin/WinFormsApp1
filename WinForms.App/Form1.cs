namespace WinForms.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any())
            {
                MessageBox.Show("Close the current form first.");
                return;
            }

            var form = new InventoryForm();
            form.MdiParent = this;
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
