using Items;
using Player;
using Survival;

namespace Core
{
    public class Game
    {
        // Idk how any of this works but it does
        Random rand = new Random();

        Character player;
        public CharacterMethods playerMethods;
        Form1 form;

        public Game(Character player, Form1 form)
        {
            this.player = player;
            this.form = form;
            playerMethods = new CharacterMethods(player, form);
        }

        // Welcome to hell
        public void BeachCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "scavange":
                    int scavange = rand.Next(0, 7);
                    if (scavange == 2)
                    {
                        Item rock = new Item("Rock", 1, 1);
                        playerMethods.AddItem(rock);
                    }
                    else
                    {
                        form.Output("You fail to find any rocks.");
                    }
                    playerMethods.Fatigue();
                    break;
                case "help":
                    BeachHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void BeachHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, help");
        }

        public void ForestCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "scavange":
                    int scavange = rand.Next(0, 17);
                    if (scavange == 2)
                    {
                        Item item = new Item("Rock", 1, 1);
                        playerMethods.AddItem(item);
                    }
                    else if (scavange == 4)
                    {
                        Item item = new Item("Branch", 1, 1);
                        playerMethods.AddItem(item);
                    }
                    else if (scavange == 6)
                    {
                        Food item = new Food("Apple", 1, 1, 15);
                        playerMethods.AddItem(item);
                    }
                    else
                    {
                        form.Output("You fail to find any items.");
                    }
                    playerMethods.Fatigue();
                    break;
                case "rest":
                    playerMethods.Rest();
                    break;
                case "help":
                    ForestHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void ForestHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, rest, help");
        }

        public void PlainsCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "scavange":
                    int scavange = rand.Next(0, 7);
                    if (scavange == 2)
                    {
                        Item item = new Item("Rock", 1, 1);
                        playerMethods.AddItem(item);
                    }
                    else
                    {
                        form.Output("You fail to find any rocks.");
                    }
                    playerMethods.Fatigue();
                    break;
                case "help":
                    PlainsHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void PlainsHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, help");
        }

        public void HillsCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "scavange":
                    int scavange = rand.Next(0, 5);
                    if (scavange == 2)
                    {
                        Item item = new Item("Rock", 1, 1);
                        playerMethods.AddItem(item);
                    }
                    else
                    {
                        form.Output("You fail to find any rocks.");
                    }
                    playerMethods.Fatigue();
                    break;
                case "help":
                    HillsHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void HillsHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, help");
        }

        public void MountainsCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "scavange":
                    int scavange = rand.Next(0, 3);
                    if (scavange == 2)
                    {
                        Item item = new Item("Rock", 1, 1);
                        playerMethods.AddItem(item);
                    }
                    else
                    {
                        form.Output("You fail to find any rocks.");
                    }
                    playerMethods.Fatigue();
                    break;
                case "help":
                    MountainsHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void MountainsHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, help");
        }

        public void VillageCommands(string command)
        {
            switch (command)
            {
                case "eat":
                    playerMethods.EatFood();
                    break;
                case "drink":
                    playerMethods.DrinkWater();
                    break;
                case "explore":
                    int num = rand.Next(0, 101);
                    Explore(num);
                    playerMethods.Fatigue();
                    break;
                case "shop":
                    // TO DO
                    // ADD LOGIC
                    break;
                case "scavange":
                    // TO DO
                    // ADD ITEMS TO SCAVANGE

                    int scavange = rand.Next(0, 17);
                    playerMethods.Fatigue();
                    break;
                case "help":
                    VillageHelp();
                    break;
                default:
                    form.Output("Unknown command: " + command);
                    break;
            }
            form.UpdateStats();
        }
        public void VillageHelp()
        {
            form.Output("Commands: eat, drink, explore, scavange, shop, help");
        }

        public void Explore(int num)
        {
            if (num <= 5)
            {
                if (player.location == "Village")
                {
                    form.Output("You decide to explore the village more.");
                }
                else
                {
                    form.Output("You stumble upon a village and encounter a few shops.");
                    player.location = "Village";
                }
                // village
            }
            else if (num > 10 && num <= 45)
            {
                if (player.location == "Forest")
                {
                    form.Output("You continue moving trough the forest.");
                }
                else
                {
                    form.Output("You enter a forest.");
                    player.location = "Forest";
                }
                // forest
            }
            else if (num > 45 && num <= 80)
            {
                if (player.location == "Plains")
                {
                    form.Output("You continue moving trough the plains.");
                }
                else
                {
                    form.Output("You enter a plains.");
                    player.location = "Plains";
                }
                // plains
            }
            else if (num > 80 && num <= 90)
            {
                if (player.location == "Hills")
                {
                    form.Output("You continue moving over the hills.");
                }
                else
                {
                    form.Output("You find yourself on a hill.");
                    player.location = "Hills";
                }
                // hills
            }
            else if (num > 90 && num <= 100)
            {
                if (player.location == "Mountains")
                {
                    form.Output("You continue navigating trough the harsh mountains.");
                }
                else
                {
                    form.Output("You enter a mountainous area.");
                    player.location = "Mountains";
                }
                // mountains
            }
        }
    }
}
