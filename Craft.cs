using Crafting;
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

        // Crafting recipes 
        public List<Recipes> recipes = []; 

        // Instantiate child class to use methods and properties of parent class
        //Materials materials = new Materials();

        // Display all recipes to be created when crafting
        // Can also add new recipes later, if need be
        public void OnCraftCreate()
        {
            //Materials campfire = new();
            //Materials spear = new();
            //Materials box = new();
            //Materials backpack = new();
            //Materials tent = new(); 
        }

        // When player selects a row and clicks button "Begin Crafting", 
        // item to be crafted will start from here
        public void Crafting()
        {

        }
    }
}
