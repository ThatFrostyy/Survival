using Survival;
using Items;

namespace Player
{
    public class Character
    {
        // Inventory
        public List<Item> inventory = [];

        // Stats
        public int healthValue = 100;
        public int hungerValue = 100;
        public int thirstValue = 100;
        public int currentWeightValue = 0;
        public int maxWeightValue = 50;
        public string location = "Beach";
    }

    public class CharacterMethods
    {
        // I don't know how any of this works, but it does
        readonly Random rand = new();

        public Character Player { get; } 
        public Form1 Form { get; }

        public CharacterMethods(Character player, Form1 form)
        {
            Player = player;
            Form = form;
        }

        // Eat
        public void EatFood()
        {
            if (Player.inventory.FirstOrDefault(item => item is Food) is Food food)
            {
                Player.hungerValue = Math.Min(Player.hungerValue + food.HungerRestore, 100);
                Form.Output($"You eat a {food.Name}. Hunger: {Player.hungerValue}");
                Player.inventory.Remove(food);
            }
            else
            {
                Form.Output("You don't have any food!");
            }
        }

        // Drink
        public void DrinkWater()
        {
            if (Player.inventory.FirstOrDefault(item => item is Drink) is Drink drink)
            {
                Player.thirstValue = Math.Min(Player.thirstValue + drink.ThirstRestore, 100);
                Form.Output($"You drink a {drink.Name}. Thirst: {Player.thirstValue}");
                Player.inventory.Remove(drink);
            }
            else
            {
                Form.Output("You don't have any drinks!");
            }
        }

        // Rest/Heal
        public void Rest()
        {
            Player.healthValue = Math.Min(Player.healthValue += rand.Next(31, 51), 100);
            Player.thirstValue = Math.Max(0, Player.thirstValue - rand.Next(31, 51));
            Player.hungerValue = Math.Max(0, Player.hungerValue - rand.Next(31, 51));
        }

        // Decrease hunger and thirst
        public void Fatigue()
        {
            Player.thirstValue = Math.Max(0, Player.thirstValue - rand.Next(1, 10));
            Player.hungerValue = Math.Max(0, Player.hungerValue - rand.Next(1, 10));

            if (Player.hungerValue <= 0 || Player.thirstValue <= 0)
            {
                FatigueDamage();
            }
        }
        // Apply damage if hunger and thirst are 0
        public void FatigueDamage()
        {
            Player.healthValue = Math.Max(0, Player.healthValue - rand.Next(6, 10));

            if (Player.healthValue <= 0)
            {
                Form.GameOver();
            }
        }

        // Can we add a item, true if we have space, false if not
        public bool CanAddItem(Item item)
        {
            return Player.currentWeightValue + item.Weight <= Player.maxWeightValue;
        }

        // Add a item
        public void AddItem(Item item)
        {
            if (CanAddItem(item))
            {
                Player.inventory.Add(item);
                Player.currentWeightValue += item.Weight;
                Form.Output($"You find and pick up a {item.Name}!");
            }
            else
            {
                Form.Output("You can't carry any more items!");
            }
        }
    }
}
