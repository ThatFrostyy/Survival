using Items;
namespace Survival
{
    public class Database
    {
        public Dictionary<string, Item> items = new()
        {
            { "Tender", new Item("Tender", 0.1, 1, "Assets/Images/Icons/Money.png", price: 1) },
            { "Branch", new Item("Branch", 1, 1, "Assets/Images/Icons/Branch.png", price: 0) },
            { "Rock", new Item("Rock", 1, 1, "Assets/Images/Icons/Rock.png", price: 0) },
        };

        public Dictionary<string, Item> weapons = new()
        {
            { "Shotgun", new Weapon("Shotgun", 3, 1, "Assets/Images/Icons/Shotgun.png", 50, 100, false, price: 600) },
        };

        public Dictionary<string, Item> foods = new()
        {
            { "Apple", new Food("Apple", 1, 1, "Assets/Images/Icons/Apple.png", 15, price: 15) },
            { "Blue Berry", new Food("Blue Berry", 0.1, 1, "Assets/Images/Icons/BlueBerry.png", 8, price: 2) },
        };

        public Dictionary<string, Item> drinks = new()
        {
        };

        public Dictionary<string, Item> medicines = new()
        {
        };
    }
}