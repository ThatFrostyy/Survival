namespace Survival
{
    public partial class CraftForm : Form
    {
        public CraftForm()
        {
            InitializeComponent();


        }

        /// <summary>
        /// Output something to the console
        /// </summary>
        public void Output(string output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
        }
    }
}
