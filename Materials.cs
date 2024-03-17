namespace Crafting
{
    public class Materials : Recipes
    {
        //public List<string> Inventory {  get; set; }

        public Materials(int playerLevel, string name, string iconPath) 
            : base(playerLevel, name, iconPath)
        { 
        }								   
    }
}
