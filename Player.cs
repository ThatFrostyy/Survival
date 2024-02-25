using Survival;
using Items;

namespace Player
{
    public class Character
    {
        // Inventory
        public List<Item> inventory = new List<Item>();

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
        // Idk how any of this works but it does
        Random rand = new Random();

        Character player;
        Form1 form;

        public CharacterMethods(Character player, Form1 form)
        {
            this.player = player;
            this.form = form;
        }

        // Eat
        public void EatFood()
        {
            Food food = player.inventory.FirstOrDefault(item => item is Food) as Food;
            if (food != null)
            {
                player.hungerValue = Math.Min(player.hungerValue + food.HungerRestore, 100);
                form.Output($"You ate {food.Name}. Hunger: {player.hungerValue}");
                player.inventory.Remove(food);
            }
            else
            {
                form.Output("You don't have any food!");
            }
        }

        // Drink
        public void DrinkWater()
        {
            Drink drink = player.inventory.FirstOrDefault(item => item is Drink) as Drink;
            if (drink != null)
            {
                player.thirstValue = Math.Min(player.thirstValue + drink.ThirstRestore, 100);
                form.Output($"You drank {drink.Name}. Thirst: {player.thirstValue}");
                player.inventory.Remove(drink);
            }
            else
            {
                form.Output("You don't have any drinks!");
            }
        }

        // Rest/Heal
        public void Rest()
        {
            player.healthValue = Math.Min(player.healthValue += rand.Next(31, 51), 100);
            player.thirstValue = Math.Max(0, player.thirstValue - rand.Next(31, 51));
            player.hungerValue = Math.Max(0, player.hungerValue - rand.Next(31, 51));
        }

        // Decrease hunger and thirst
        public void Fatigue()
        {
            player.thirstValue = Math.Max(0, player.thirstValue - rand.Next(1, 10));
            player.hungerValue = Math.Max(0, player.hungerValue - rand.Next(1, 10));

            if (player.hungerValue <= 0 || player.thirstValue <= 0)
            {
                FatigueDamge();
            }
        }
        // Apply damage if hunger and thirst are 0
        public void FatigueDamge()
        {
            player.healthValue = Math.Max(0, player.healthValue - rand.Next(6, 10));

            if (player.healthValue <= 0)
            {
                form.GameOver();
            }
        }

        // Can we add a item, true if we have space, false if not
        public bool CanAddItem(Item item)
        {
            return player.currentWeightValue + item.Weight <= player.maxWeightValue;
        }

        // Add a item
        public void AddItem(Item item)
        {
            if (CanAddItem(item))
            {
                player.inventory.Add(item);
                player.currentWeightValue += item.Weight;
                form.Output($"You find and pick up a {item.Name}!");
            }
            else
            {
                form.Output("You can't carry any more items!");
            }
        }
    }
}
