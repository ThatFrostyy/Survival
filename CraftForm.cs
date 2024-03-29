﻿namespace Survival
{
    public partial class CraftForm : Form
    {
        //private readonly Database _database;
        //private readonly Character _character;
        public readonly Craft _craftForm;

        public CraftForm()
        {
            InitializeComponent();

            _craftForm = new Craft(this);

            _craftForm.OnCraftCreate();
			_craftForm.DisplayCraftingRecipes();				
        }

        #region GUI
        /// <summary>
        /// Output something to the console
        /// </summary>
        public void Output(string output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
        }
        #endregion GUI
    }
}
