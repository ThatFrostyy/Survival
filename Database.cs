using Crafting;
using Enemies;
using Items;
namespace Survival
{
    public class Database
    {
        private static readonly Random _rand = new();

        // World Items
        public Dictionary<string, Item> items = new()
        {
            { "Tender", new Item("Tender", 0.1, 1, "Assets/Images/Icons/Money.png", price: 1) },
            { "Branch", new Item("Branch", 0.5, 1, "Assets/Images/Icons/Branch.png", price: 0) },
            { "Rock", new Item("Rock", 0.5, 1, "Assets/Images/Icons/Rock.png", price: 0) },
            { "Hammer", new Item("Hammer", 0.8, 1, "Assets/Images/Icons/Hammer.png", price: 50) },
        };

        public Dictionary<string, Item> weapons = new()
        {
            { "Shotgun", new Weapon("Shotgun", 3, 1, "Assets/Images/Icons/Shotgun.png", 50, 100, false, price: 600) },
            { "Spear", new Weapon("Spear", 1.7, 1, "Assets/Images/Icons/Spear.png", 30, 100, true, price: 100) },
        };

        public Dictionary<string, Item> foods = new()
        {
            { "Apple", new Food("Apple", 0.3, 1, "Assets/Images/Icons/Apple.png", 15, price: 15) },
            { "Blue Berry", new Food("Blue Berry", 0.1, 1, "Assets/Images/Icons/BlueBerry.png", 8, price: 2) },
        };

        public Dictionary<string, Item> drinks = new()
        {
            { "Water Bottle", new Drink("Water Bottle", 0.5, 1, "Assets/Images/Icons/WaterBottle.png", 30, price: 20) },
        };

        public Dictionary<string, Item> medicines = new()
        {
            { "Bandage", new Medicine("Bandage", 0.2, 1, "Assets/Images/Icons/Bandage.png", 30, price: 30) },
        };

        // Shop
        public List<Item> shopItems =
        [
            new Food("Apple", 0.3, 1, "Assets/Images/Icons/Apple.png", 15, stock: _rand.Next(1, 11), price: 15),
            new Drink("Water Bottle", 0.5, 1, "Assets/Images/Icons/WaterBottle.png", 30, stock: _rand.Next(1, 6), price: 20),
            new Medicine("Bandage", 0.2, 1, "Assets/Images/Icons/Bandage.png", 30, stock: _rand.Next(1, 6), price: 30),
            new Weapon("Shotgun", 3, 1, "Assets/Images/Icons/Shotgun.png", 50, 100, false, 1, 600)
        ];

        // Enemies
        public List<Enemy> enemies =
        [
            new Enemy("Peasant", 100, 0, _rand.Next(0, 11), false),
            new Enemy("Bandit", 100, 0, _rand.Next(9, 21), false),
            new Enemy("Forest Bandit", 100, _rand.Next(9, 31), _rand.Next(9, 21), false),
            new Enemy("Wasteland Raider", 100, _rand.Next(11, 21), _rand.Next(9, 21), false),
            new Enemy("Raider", 130, _rand.Next(31, 51), _rand.Next(21, 31), false),
        ];

        // Crafting Recipes
        public List<Recipes> recipes =
        [
            new Materials(1, "Campfire", "Assets/Images/Icons/Campfire.png", "5 Branches, 3 Rocks"),
            new Materials(1, "Spear", "Assets/Images/Icons/Spear.png", "3 Branches, 1 Rope"),
            new Materials(1, "Bow", "Assets/Images/Icons/Bow.png", "3 Branches, 2 Rope"),
            new Materials(1, "Makeshift Backpack", "Assets/Images/Icons/MakeshiftBackpack.png", "3 Cloth, 1 Tarp, 1 Rope"),
            new Materials(1, "Tent", "Assets/Images/Icons/Tent.png", "3 Tarp, 2 Rope")
        ]; 

        public List<int> enemyWeights = [30, 40, 20, 5, 5];
    }
}