namespace Survival
{
    public partial class CraftForm : Form
    {
        public CraftForm()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
