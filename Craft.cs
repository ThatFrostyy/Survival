namespace Survival
{
    public class Craft
    {
        // See Recipes.cs for all the recipes

        private readonly CraftForm _craftForm;
        private readonly Database _database;
        private readonly Tools _tools;
        //private readonly Character _character;

        public Craft(CraftForm craft, Database database, Tools tools)
        {
            _craftForm = craft;
            _database = database;
            _tools = tools;
        }

        #region Other
        /// <summary>
        /// Called on the game start, useful for adding items/materials to the crafting system
        /// </summary>
        public void OnCraftCreate()
        {
        }
        #endregion Other

        #region Crafting Methods
        /// <summary>
        /// After the player selects a row and clicks begin crafting, items to be crafted will start from here
        /// </summary>
        public void Crafting()
        {
            _craftForm.craftButton.Enabled = false; 
        }


        #endregion Crafting Methods

        #region GUI
        /// <summary>
        /// Called when the player opens the crafting menu
        /// </summary>
        public void DisplayCraftingRecipes()
        {
            // Add columns 
            // They are always added through code because they are not set in the designer
            if (_craftForm.recipeGrid.Columns.Count == 0)
            {
                var iconColumn = new DataGridViewImageColumn
                {
                    Name = "Icon",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                _craftForm.recipeGrid.Columns.Add(iconColumn);
                _craftForm.recipeGrid.Columns.Add("Name", "Name");
                _craftForm.recipeGrid.Columns.Add("Player Level", "Player Level");
                _craftForm.recipeGrid.Columns.Add("Materials", "Materials");
            }

            _craftForm.recipeGrid.Rows.Clear();

            foreach (var recipe in _database.recipes)
            {
                if (recipe == null)
                {
                    continue;
                }

                // Check if there's already a row for this item
                var existingRow = _craftForm.recipeGrid.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == recipe.Name);

                if (existingRow == null)																 
                {
                    var index = _craftForm.recipeGrid.Rows.Add();
                    var row = _craftForm.recipeGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(recipe.Icon);
                    row.Cells["Name"].Value = recipe.Name;
                    row.Cells["Player Level"].Value = recipe.PlayerLevel;
                    row.Cells["Materials"].Value = recipe.PlayerInventory; 
                }
            }
            _craftForm.recipeGrid.CellMouseEnter += RecipeGrid_CellMouseEnter;
        }
        public void RecipeGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _craftForm.recipeGrid.Rows[e.RowIndex];
            var recipe = _database.recipes.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());
            var tooltip = string.Empty;

            switch (recipe.Name)
            {
                case "Campfire":
                    tooltip = "Time: 1m 30s";
                    break;
                case "Spear":
                    tooltip = "Time: 1m";
                    break;
                case "Bow":
                    tooltip = "Time: 1m";
                    break;
                case "Makeshift Backpack":
                    tooltip = "Time: 1m 30s";
                    break;
                case "Tent":
                    tooltip = "Time: 2m";
                    break;
                default:
                    tooltip = "Unknown item";
                    break;
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ToolTipText = tooltip;
            }
        }
        #endregion GUI

    }
}
