namespace Crafting
{
    public class Recipes
    {
        // Recipes: 
        // Campfire: 5 branches, 3 rocks
        // Spear: 3 branches, 1 rope
        // Box: 3 branches, 2 rope
        // Makeshift backpack: 3 cloth, 1 tarp, 1 rope
        // Tent: 3 tarp, 2 rope

        public Guid Id { get; set; }
        public int PlayerLevel { get; set; }
        public string Name { get; set; }
        public Image Icon { get; set; }

        // Constructor 
        public Recipes(int playerLevel, string name, string iconPath) 
        { 
            Id = Guid.NewGuid();
            PlayerLevel = playerLevel;
            Name = name; 
            Icon = Image.FromFile(iconPath);
        }
    }
}
