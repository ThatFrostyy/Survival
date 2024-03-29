using Survival;

namespace Crafting
{
    public class Materials : Recipes
    {
        public Materials(int playerLevel, string name, string iconPath, string playerInventory)
            : base(playerLevel, name, iconPath, playerInventory)
        {
            // TODO: Add getters and setters to drain food/hunger when crafting? 
        }
        
        // TODO: Add logic to retrieve inventory items 

    }
}
