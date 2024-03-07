/*  <A text based survival game.>
    Copyright (C) <2024> <Frostyy>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>. */

using Items;
using Enemies;
using Player;
using Survival;
using Shop;
using Utilities;

namespace Core
{
    public class Game
    {
        // I don't know how any of this works, but it does
        readonly Random rand = new();
        public Character Player { get; }
        public CharacterMethods PlayerMethods { get; }
        public ShopCore Shop { get; }
        public ShopMethods ShopMethods { get; }
        public Form1 Form { get; }
        public Options Settings { get; }
        public Tools Utilities { get; }

        public Game(ShopCore shop, Character player, Form1 form, Options settings, Tools utilities)
        {
            Shop = shop;
            ShopMethods = new ShopMethods(shop, form, player, PlayerMethods);
            Player = player;
            PlayerMethods = new CharacterMethods(player, form);
            Form = form;
            Settings = settings;
            Utilities = utilities;
        }

        // Commands
        public void BeachCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 12:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 12 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 30:
                            Item rock = new("Rock", 1, 1, "Assets/Images/Icons/Rock.png");
                            PlayerMethods.AddItem(rock);
                            break;
                        default:
                            Form.Output("You fail to find any rocks.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Beach Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void ForestCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 15:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 15 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 30:
                            Item rock = new("Rock", 1, 1, "Assets/Images/Icons/Rock.png");
                            PlayerMethods.AddItem(rock);
                            break;
                        case > 30 and <= 60:
                            Item branch = new("Branch", 1, 1, "Assets/Images/Icons/Branch.png");
                            PlayerMethods.AddItem(branch);
                            break;
                        case > 60 and <= 75:
                            Food apple = new("Apple", 1, 1, "Assets/Images/Icons/Apple.png", 15);
                            PlayerMethods.AddItem(apple);
                            break;
                        default:
                            Form.Output("You fail to find any items.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "rest":
                    PlayerMethods.Rest();
                    break;
                case "help":
                    Form.Output("Forest Commands: equip, heal, eat, drink, explore, scavenge, rest, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;

            }
            Form.UpdateStats();
        }

        public void PlainsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 12:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 12 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 30:
                            Item item = new("Rock", 1, 1, "Assets/Images/Icons/Rock.png");
                            PlayerMethods.AddItem(item);
                            break;
                        default:
                            Form.Output("You fail to find any rocks.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Plains Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void HillsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 12:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 12 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 50:
                            Item item = new("Rock", 1, 1, "Assets/Images/Icons/Rock.png");
                            PlayerMethods.AddItem(item);
                            break;
                        default:
                            Form.Output("You fail to find any rocks.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Hills Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void MountainsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 15:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 15 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 75:
                            Item item = new("Rock", 1, 1, "Assets/Images/Icons/Rock.png");
                            PlayerMethods.AddItem(item);
                            break;
                        default:
                            Form.Output("You fail to find any rocks.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Mountains Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void VillageCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        PlayerMethods.EquipItem(command.Argument);
                    }
                    else
                    {
                        Form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "eat":
                    PlayerMethods.EatFood();
                    break;
                case "drink":
                    PlayerMethods.DrinkWater();
                    break;
                case "explore":
                    var num = rand.Next(0, 101);
                    var encounter = rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 15:
                            Form.Output("You suddenly get attacked by an enemy! You enter combat.");
                            Player.inCombat = true;
                            break;
                        case > 15 and <= 100:
                            Explore(num);
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "shop":
                    Form.shopGrid.Visible = true;
                    ShopMethods.UpdateShop();
                    Player.inShop = true;
                    break;
                case "scavenge":
                    var scavenge = rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 10:
                            Item item = new("Tender", 0.1, rand.Next(0, 11), "Assets/Images/Icons/Money.png");
                            PlayerMethods.AddItem(item);
                            break;
                        default:
                            Form.Output("You fail to find any items.");
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Village Commands: equip, heal, eat, drink, explore, scavenge, shop, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void CombatCommands(Command command)
        {
            switch (command.Action)
            {
                case "heal":
                    PlayerMethods.Heal();
                    break;
                case "fight":
                    Fight();
                    break;
                case "retreat":
                    var chance = rand.Next(0, 101);

                    switch (chance)
                    {
                        case <= 35:
                            Player.inCombat = false;
                            Form.Output("You successfully retreat out of combat.");
                            break;
                        default:
                            Form.Output("You fail to retreat and receive some damage.");
                            PlayerMethods.FatigueDamage();
                            break;
                    }
                    PlayerMethods.Fatigue();
                    break;
                case "help":
                    Form.Output("Combat Commands: fight, heal, retreat, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        // Add selling
        public void ShopCommands(Command command)
        {
            switch (command.Action)
            {
                case "buy":
                    ShopMethods.Buy(command);
                    ShopMethods.UpdateShop();
                    PlayerMethods.UpdateInventory();
                    break;
                case "sell":
                    break;
                case "leave":
                    Form.Output("You decide to leave the shop.");
                    ShopMethods.UpdateShop();
                    Form.shopGrid.Visible = false;
                    Player.inShop = false;
                    break;
                case "help":
                    Form.Output("Shop Commands: buy, sell, leave, help");
                    break;
                default:
                    Form.Output("Unknown command: " + command);
                    break;
            }
            Form.UpdateStats();
        }

        public void Explore(int num)
        {
            switch (num)
            {  
                case <= 5:
                    if (Player.location == "Village")
                    {
                        Form.Output("You decide to explore the village more.");
                    }
                    else
                    {
                        Form.Output("You stumble upon a village and encounter a few shops.");
                        Player.location = "Village";
                    }
                    break;
                case > 10 and <= 45:
                    if (Player.location == "Forest")
                    {
                        Form.Output("You continue moving through the forest.");
                    }
                    else
                    {
                        Form.Output("You enter a forest.");
                        Player.location = "Forest";
                    }
                    break;
                case > 45 and <= 80:
                    if (Player.location == "Plains")
                    {
                        Form.Output("You continue moving through the plains.");
                    }
                    else
                    {
                        Form.Output("You enter a plains.");
                        Player.location = "Plains";
                    }
                    break;
                case > 80 and <= 90:
                    if (Player.location == "Hills")
                    {
                        Form.Output("You continue moving over the hills.");
                    }
                    else
                    {
                        Form.Output("You find yourself on a hill.");
                        Player.location = "Hills";
                    }
                    break;
                case > 90 and <= 100:
                    if (Player.location == "Mountains")
                    {
                        Form.Output("You continue navigating through the harsh mountains.");
                    }
                    else
                    {
                        Form.Output("You enter a mountainous area.");
                        Player.location = "Mountains";
                    }
                    break;
            }
        }

        public async void Fight()
        {
            var enemies = new List<Enemy>
            {
                new("Peasant", 100, 0, rand.Next(0, 11), false),
                new("Bandit", 100, 0, rand.Next(9, 21), false),
                new("Forest Bandit", 100, rand.Next(9, 31), rand.Next(9, 21), false),
                new("Wounded Raider", rand.Next(79, 101), rand.Next(11, 21), rand.Next(9, 21), false),
                new("Raider", 100, rand.Next(31, 51), rand.Next(21, 31), false),
            };
            List<int> weights = [30, 40, 20, 5, 5];

            var enemy = Utilities.ChooseWeightedRandom(enemies, weights);

            while (Player.healthValue > 0 && enemy.Health > 0)
            {
                Weapon? equippedWeapon = null;
                if (Player.inventory.Find(item => item.Id == Player.equippedItem) is Weapon weapon)
                {
                    equippedWeapon = weapon;
                }

                var playerDamage = equippedWeapon != null ? equippedWeapon.Damage : Player.strengthValue;

                if (equippedWeapon != null && rand.Next(100) < 50)
                {
                    equippedWeapon.Durability -= 1;
                    if (equippedWeapon.Durability <= 0)
                    {
                        Form.Output($"Your {equippedWeapon.Name} has broken!");
                        equippedWeapon = null;
                    }
                }

                var playerAttack = Math.Max(0, playerDamage - enemy.Armor);
                enemy.Health -= playerAttack;

                Form.Output($"You attacked the {enemy.Name} for {playerAttack} points, he has {enemy.Health} health and {enemy.Armor} armor points left.");

                if (rand.Next(100) < 50 && enemy.Armor > 0)
                {
                    enemy.Armor -= playerAttack;
                    if (enemy.Armor < 0)
                    {
                        enemy.Armor = 0;
                    }
                    Form.Output($"You damage the {enemy.Name}'s armor for {playerAttack} points!");
                }

                await Task.Delay(2000);

                if (enemy.Health <= 0)
                {
                    continue;
                }

                var enemyAttack = enemy.Damage - Player.armorValue;
                Player.healthValue -= enemyAttack;
                Form.Output($"The {enemy.Name} attacked you for {enemyAttack} points, you have {Player.healthValue} health and {Player.armorValue} armor points left.");


                var str = Settings.healPoint.Text;
                var num = int.Parse(str);
                if (Player.healthValue < num && Settings.autoHeal.Checked)
                {
                    PlayerMethods.Heal();
                }

                Form.UpdateStats();
            }

            if (Player.healthValue > 0)
            {
                Form.Output($"You defeat the {enemy.Name}!");
                PlayerMethods.AddXp();
                Player.inCombat = false;
            }
            else
            {
                Form.Output($"You were defeated by the {enemy.Name}...");
                Form.GameOver();
            }

            Form.UpdateStats();
        }
    }
}