namespace Crafting
{
    public class Materials : Recipes
    {
        //public List<string> Inventory {  get; set; }

        public Materials(int playerXP, string name, string iconPath) 
            : base(playerXP, name, iconPath)
        { 
        }

        // Retrieve materials from player inventory

    }
}
