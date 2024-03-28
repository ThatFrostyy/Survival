using Crafting;
namespace Survival
{
    public class Craft
    {
        // See Recipes.cs for all the recipes

        private readonly CraftForm _craftForm;
        // I assume that the code bellow will be used in the future, so I won't delete it..
        //private readonly Character _character;

        #region Lists
        // Crafting recipes 
        public List<Recipes> recipes = [];
        #endregion

        public Craft(CraftForm craft) 
        {
            _craftForm = craft; 
        }

        #region Other
        /// <summary>
        /// Called on the game start, useful for adding items/materials to the crafting system
        /// </summary>
        public void OnCraftCreate()
        {
            Materials campfire = new(3, "Campfire", "Assets/Images/Icons/Campfire.png", "5 Branches, 3 Rocks");
            Materials spear = new(4, "Spear", "Assets/Images/Icons/Spear.png", "3 Branches, 1 Rope");
            Materials bow = new(5, "Bow", "Assets/Images/Icons/Bow.png", "3 Branches, 2 Rope");
            Materials backpack = new(6, "Makeshift Backpack", "Assets/Images/Icons/MakeshiftBackpack.png", "3 Cloth, 1 Tarp, 1 Rope");
            Materials tent = new(7, "Tent", "Assets/Images/Icons/Tent.png", "3 Tarp, 2 Rope");
            recipes.Add(campfire);
            recipes.Add(spear);
            recipes.Add(bow);
            recipes.Add(backpack);
            recipes.Add(tent);
        }
        #endregion Other

        #region Crafting Methods
        /// <summary>
        /// After the player selects a row and clicks begin crafting, items to be crafted will start from here
        /// </summary>
        public void Crafting()
        {
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
                _craftForm.recipeGrid.Columns.Add("Player Level", "Player Level");
                _craftForm.recipeGrid.Columns.Add("Name", "Name");
                //_craftForm.recipeGrid.Columns.Add("Materials", "Materials");
            }

            _craftForm.recipeGrid.Rows.Clear();

            foreach (var recipe in recipes)
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
                    row.Cells["Player Level"].Value = recipe.PlayerLevel;
                    row.Cells["Name"].Value = recipe.Name;
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
            var recipe = recipes.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());
            var tooltip = string.Empty;

            switch (recipe)
            {
                case Materials campfire:
                    tooltip = "Time: 3 minutes";
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
