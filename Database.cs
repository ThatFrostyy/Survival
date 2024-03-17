using Items;
namespace Survival
{
    public class Database
    {
        // DO NOT EDIT THIS IF YOU ARE TRYING TO CHANGE THE ITEM IN THE SHOP
        // TO DO THAT GO TO THE METHOD OnShopCreate in Shop.cs
        public Dictionary<string, Item> items = new()
        {
            { "Tender", new Item("Tender", 0.1, 1, "Assets/Images/Icons/Money.png", price: 1) },
            { "Branch", new Item("Branch", 1, 1, "Assets/Images/Icons/Branch.png", price: 0) },
            { "Rock", new Item("Rock", 1, 1, "Assets/Images/Icons/Rock.png", price: 0) },
        };

        public Dictionary<string, Item> weapons = new()
        {
            { "Shotgun", new Weapon("Shotgun", 3, 1, "Assets/Images/Icons/Shotgun.png", 50, 100, false, price: 600) },
            // Melee is not implemented yet so this item won't do shit (for now)
            { "Spear", new Weapon("Spear", 2, 1, "Assets/Images/Icons/Spear.png", 30, 100, true, price: 100) },
        };

        public Dictionary<string, Item> foods = new()
        {
            { "Apple", new Food("Apple", 1, 1, "Assets/Images/Icons/Apple.png", 15, price: 15) },
            { "Blue Berry", new Food("Blue Berry", 0.1, 1, "Assets/Images/Icons/BlueBerry.png", 8, price: 2) },
        };

        public Dictionary<string, Item> drinks = new()
        {
            { "Water Bottle", new Drink("Water Bottle", 1, 1, "Assets/Images/Icons/WaterBottle.png", 30, price: 20) },
        };

        public Dictionary<string, Item> medicines = new()
        {
            { "Bandage", new Medicine("Bandage", 0.2, 1, "Assets/Images/Icons/Bandage.png", 30, price: 30) },
        };
    }
}