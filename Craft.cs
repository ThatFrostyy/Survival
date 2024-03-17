using Crafting;
using Items;
using System.Windows.Forms;
namespace Survival
{
    public class Craft
    {
        // Recipes: 
        // Campfire: 5 branches, 3 rocks
        // Spear: 3 branches, 1 rope
        // Box: 3 branches, 2 rope
        // Makeshift backpack: 3 cloth, 1 tarp, 1 rope
        // Tent: 3 tarp, 2 rope

        private readonly CraftForm _craftForm;
        //private readonly Character _character;

        // Crafting recipes 
        public List<Recipes> recipes = []; 

        public Craft(CraftForm craft) 
        {
            _craftForm = craft; 
        }

        // Instantiate child class to use methods and properties of parent class
        //Materials materials = new Materials();

        // Display all recipes to be created when crafting
        // Can also add new recipes later, if need be
        public void OnCraftCreate()
        {
            Materials campfire = new(3, "Campfire", "Assets/Images/Icons/Campfire.png");
            Materials spear = new(4, "Spear", "Assets/Images/Icons/Spear.png");
            Materials bow = new(5, "Bow", "Assets/Images/Icons/Bow.png");
            Materials backpack = new(6, "Makeshift Backpack", "Assets/Images/Icons/MakeshiftBackpack.png");
            Materials tent = new(7, "Tent", "Assets/Images/Icons/Tent.png"); 
            recipes.Add(campfire); 
            recipes.Add(spear); 
            recipes.Add(bow); 
            recipes.Add(backpack);
            recipes.Add(tent); 
        }

        // Display the recipes for crafting
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

                if (existingRow != null)
                {
                    //existingRow.Cells["Stock"].Value = recipe.Stock;
                }
                else
                {
                    var index = _craftForm.recipeGrid.Rows.Add();
                    var row = _craftForm.recipeGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(recipe.Icon);
                    row.Cells["Player Level"].Value = recipe.PlayerXP;
                    row.Cells["Name"].Value = recipe.Name;
                }
            }
            /*
            if (_character.inShop == false)
            {
                _form.Output("You enter the village shop.");
            }
            */
            _craftForm.recipeGrid.CellMouseEnter += RecipeGrid_CellMouseEnter;
        }

        // When player selects a row and clicks button "Begin Crafting", 
        // item to be crafted will start from here
        public void Crafting()
        {

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
                    tooltip = "Unknown item type";
                    break;
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ToolTipText = tooltip;
            }
        }
    }
}
