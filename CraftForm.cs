namespace Survival
{
    public partial class CraftForm : Form
    {
        private readonly Database _database;
        //private readonly Character _character;
        public readonly Craft _craft;
        public readonly Tools _tools;

        public CraftForm(Tools tools)
        {
            InitializeComponent();

            _tools = tools;

            _database = new Database();
            _craft = new Craft(this, _database, _tools);

            _craft.OnCraftCreate();
            _craft.DisplayCraftingRecipes();

            recipeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #region GUI
        /// <summary>
        /// Output something to the console
        /// </summary>
        public void Output(string ?output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
        }

        #endregion GUI

        #region Crafting
        private void craftButton_Click(object sender, EventArgs e)
        {
            _craft.Crafting(); 
        }
        #endregion Crafting
    }
}
