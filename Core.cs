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
using Settings;
namespace Survival
{
    public class Game
    {
        private readonly Random _rand = new();
        private readonly Form1 _form;
        private readonly Character _character;
        private readonly Database _database;
        private readonly Shop _shop;
        private readonly Tools _tools;
        private readonly Options _options;

        private Enemy _currentEnemy;
        public Game(Form1 form, Character character, Database database, Shop shop, Tools tools, Options options)
        {
            _form = form;
            _character = character;
            _database = database;
            _shop = shop;
            _tools = tools;
            _options = options;
        }

        #region Location Commands
        public void BeachCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 8:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat.");
                            _character.inCombat = true;
                            break;
                        case > 8 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);

                    switch (scavenge)
                    {
                        case <= 30:
                            _character.CreateItem("Rock");
                            break;
                        default:
                            _form.Output("You fail to find any rocks.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Beach Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }

        public void ForestCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 12:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat."); _character.inCombat = true;
                            break;
                        case > 12 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);
                    switch (scavenge)
                    {
                        case <= 30:
                            _character.CreateItem("Rock");
                            break;
                        case > 30 and <= 60:
                            _character.CreateItem("Branch");
                            break;
                        case > 60 and <= 75:
                            _character.CreateFood("Apple");
                            break;
                        case > 75 and <= 82:
                            _character.CreateFood("Blue Berry", newQuantity: 3);
                            break;
                        default:
                            _form.Output("You fail to find any items.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "rest":
                    _character.Rest();
                    break;
                case "help":
                    _form.Output("Forest Commands: equip, heal, eat, drink, explore, scavenge, rest, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;

            }
            _form.UpdateStats();
        }

        public void PlainsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 8:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat."); _character.inCombat = true;
                            break;
                        case > 8 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);
                    switch (scavenge)
                    {
                        case <= 30:
                            _character.CreateItem("Rock");
                            break;
                        default:
                            _form.Output("You fail to find any rocks.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Plains Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }

        public void HillsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 8:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat."); _character.inCombat = true;
                            break;
                        case > 8 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);
                    switch (scavenge)
                    {
                        case <= 50:
                            _character.CreateItem("Rock");
                            break;
                        default:
                            _form.Output("You fail to find any rocks.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Hills Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }

        public void MountainsCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 8:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat."); _character.inCombat = true;
                            break;
                        case > 8 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);
                    switch (scavenge)
                    {
                        case <= 75:
                            _character.CreateItem("Rock");
                            break;
                        default:
                            _form.Output("You fail to find any rocks.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Mountains Commands: equip, heal, eat, drink, explore, scavenge, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }

        public void VillageCommands(Command command)
        {
            switch (command.Action)
            {
                case "equip":
                    if (command.Argument != null)
                    {
                        _character.EquipItem(command.Argument);
                    }
                    else
                    {
                        _form.Output("Please specify an item to equip.");
                    }
                    break;
                case "heal":
                    _character.Heal(command);
                    break;
                case "eat":
                    _character.Eat(command);
                    break;
                case "drink":
                    _character.Drink(command);
                    break;
                case "explore":
                    var num = _rand.Next(0, 101);
                    var encounter = _rand.Next(0, 101);

                    switch (encounter)
                    {
                        case <= 12:
                            CreateEnemy();
                            _form.Output($"You suddenly get attacked by a {_currentEnemy.Name} and enter combat."); _character.inCombat = true;
                            break;
                        case > 12 and <= 100:
                            Explore(num);
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "shop":
                    _form.shopGrid.Visible = true;
                    _shop.UpdateShop();
                    _character.inShop = true;
                    break;
                case "scavenge":
                    var scavenge = _rand.Next(0, 101);
                    var money = _rand.Next(0, 11);
                    switch (scavenge)
                    {
                        case <= 10:
                            _character.CreateItem("Tender", newQuantity: money, newPrice: money);
                            break;
                        default:
                            _form.Output("You fail to find any items.");
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Village Commands: equip, heal, eat, drink, explore, scavenge, shop, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }
        #endregion Location Commands

        #region Specific Places
        public void CombatCommands(Command command)
        {
            switch (command.Action)
            {
                case "heal":
                    _character.Heal(command);
                    break;
                case "fight":
                    Fight();
                    break;
                case "retreat":
                    var chance = _rand.Next(0, 101);
                    switch (chance)
                    {
                        case <= 35:
                            _character.inCombat = false;
                            _form.Output("You successfully retreat out of combat.");
                            break;
                        default:
                            _form.Output("You fail to retreat and receive some damage.");
                            _character.FatigueDamage();
                            break;
                    }
                    _character.Fatigue();
                    break;
                case "help":
                    _form.Output("Combat Commands: fight, heal, retreat, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }

        // Improve the shop selling method
        // Currently the Buy and Sell methods don't work because _character is always null in ShopMethods
        public void ShopCommands(Command command)
        {
            switch (command.Action)
            {
                case "buy":
                    _shop.Buy(command);
                    _shop.UpdateShop();
                    break;
                case "sell":
                    _shop.Sell(command);
                    break;
                case "leave":
                    _form.Output("You decide to leave the shop.");
                    _shop.UpdateShop();
                    _form.shopGrid.Visible = false;
                    _character.inShop = false;
                    break;
                case "help":
                    _form.Output("Shop Commands: buy, sell, leave, help");
                    break;
                default:
                    _form.Output("Unknown command: " + command.Action);
                    break;
            }
            _form.UpdateStats();
        }
        #endregion

        #region Game Methods
        public void Explore(int num)
        {
            switch (num)
            {
                case <= 5:
                    if (_character.location == "Village")
                    {
                        _form.Output("You decide to explore the village more.");
                    }
                    else
                    {
                        _form.Output("You stumble upon a village and encounter a few shops.");
                        _character.location = "Village";
                    }
                    break;
                case > 10 and <= 45:
                    if (_character.location == "Forest")
                    {
                        _form.Output("You continue moving through the forest.");
                    }
                    else
                    {
                        _form.Output("You enter a forest.");
                        _character.location = "Forest";
                    }
                    break;
                case > 45 and <= 80:
                    if (_character.location == "Plains")
                    {
                        _form.Output("You continue moving through the plains.");
                    }
                    else
                    {
                        _form.Output("You enter a plains.");
                        _character.location = "Plains";
                    }
                    break;
                case > 80 and <= 90:
                    if (_character.location == "Hills")
                    {
                        _form.Output("You continue moving over the hills.");
                    }
                    else
                    {
                        _form.Output("You find yourself on a hill.");
                        _character.location = "Hills";
                    }
                    break;
                case > 90 and <= 100:
                    if (_character.location == "Mountains")
                    {
                        _form.Output("You continue navigating through the harsh mountains.");
                    }
                    else
                    {
                        _form.Output("You enter a mountainous area.");
                        _character.location = "Mountains";
                    }
                    break;
            }
        }

        private void CreateEnemy()
        {
            var enemy = _tools.ChooseWeightedRandom(_database.enemies, _database.enemyWeights);
            _currentEnemy = enemy;
        }

        public async void Fight()
        {
            while (_character.healthValue > 0 && _currentEnemy.Health > 0)
            {
                Weapon? equippedWeapon = null;
                if (_character.inventory.Find(item => item.Id == _character.equippedItem) is Weapon weapon)
                {
                    equippedWeapon = weapon;
                }

                var playerDamage = equippedWeapon != null ? equippedWeapon.Damage : _character.strengthValue;

                if (equippedWeapon != null && _rand.Next(100) < 50)
                {
                    equippedWeapon.Durability -= 1;
                    if (equippedWeapon.Durability <= 0)
                    {
                        _form.Output($"Your {equippedWeapon.Name} has broken!");
                        equippedWeapon = null;
                    }
                }

                if (equippedWeapon == null)
                {
                    playerDamage = _character.strengthValue;
                }

                var playerAttack = Math.Max(0, playerDamage - _currentEnemy.Armor);
                _currentEnemy.Health -= playerAttack;

                _tools.PlaySound(string.Empty, equippedWeapon, true);

                _form.Output($"You attacked the {_currentEnemy.Name} for {playerAttack} points, he has {_currentEnemy.Health} health and {_currentEnemy.Armor} armor points left.");

                if (_rand.Next(100) < 50 && _currentEnemy.Armor > 0)
                {
                    _currentEnemy.Armor -= playerAttack;
                    if (_currentEnemy.Armor < 0)
                    {
                        _currentEnemy.Armor = 0;
                    }
                    _form.Output($"You damage the {_currentEnemy.Name}'s armor for {playerAttack} points!");
                }

                await Task.Delay(2000);

                if (_currentEnemy.Health <= 0)
                {
                    break;
                }

                var currentEnemyAttack = Math.Max(0, _currentEnemy.Damage - _character.armorValue);
                _character.healthValue -= currentEnemyAttack;
                _form.Output($"The {_currentEnemy.Name} attacked you for {currentEnemyAttack} points, you have {_character.healthValue} health and {_character.armorValue} armor points left.");


                var str = _options.healPoint.Text;
                var num = int.Parse(str);
                if (_character.healthValue < num && _options.autoHeal.Checked)
                {
                    _character.Heal();
                }

                _form.UpdateStats();
            }

            if (_character.healthValue > 0)
            {
                _form.Output($"You defeat the {_currentEnemy.Name}!");
                _character.AddXp();
                _character.inCombat = false;
            }
            else
            {
                _form.Output($"You were defeated by the {_currentEnemy.Name}...");
                _form.GameOver();
            }

            _form.UpdateStats();
        }
        #endregion Game Methods
    }
}