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

using Survival;
using Items;
namespace Player
{
    public class Character
    {
        // Keeps track of all the picked up items and their gui's 
        public Dictionary<DataGridViewRow, Item> itemDic = [];

        // Inventory
        public List<Item> inventory = [];

        // Stats
        public int xpValue = 0;
        public int levelValue = 1;
        public int strengthValue = 15;

        // General
        public int healthValue = 100;
        public int hungerValue = 100;
        public int thirstValue = 100;
        public int armorValue = 0;
        public double currentWeightValue = 0;
        public int maxWeightValue = 30;
        public string location = "Beach";

        // Other
        public bool inCombat = false;
        public bool inShop = false;
        public Guid equippedItem = Guid.Empty;
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

        /// <summary>
        /// Called on the game start, useful for adding items to the inventory, testing, etc
        /// </summary>
        public void OnPlayerCreate()
        {
            /*
            Weapon test = new("Shotgun", 0.1, 10, "Assets/Images/Icons/Shotgun.png", 50, 100, false);
            AddItem(test);
            Item item = new("Tender", 0.1, 200, "Assets/Images/Icons/Money.png");
            AddItem(item);
            Medicine a = new("Bandage", 0.1, 200, "Assets/Images/Icons/Bandage.png", 30);
            AddItem(a);*/
        }

        /// <summary>
        /// Add xp to the player
        /// </summary>
        public void AddXp()
        {
            var add = rand.Next(1, 11);
            Player.xpValue += add;

            if (Player.xpValue >= 100)
            {
                Player.levelValue++;
                Player.xpValue = 0;
                Form.Output($"You have leveled up to level {Player.levelValue}!");
            }

            Form.Output($"You gained {add} xp!");
        }

        /// <summary>
        /// Eat an eatable item
        /// </summary>
        public void EatFood()
        {
            if (Player.inventory.FirstOrDefault(item => item is Food) is Food food)
            {
                Player.hungerValue = Math.Min(Player.hungerValue + food.HungerRestore, 100);
                Form.Output($"You eat a {food.Name}. Hunger: {Player.hungerValue}");
                RemoveItem(food);
            }
            else
            {
                Form.Output("You don't have any food!");
            }
        }

        /// <summary>
        /// Drink a drink
        /// </summary>
        public void DrinkWater()
        {
            if (Player.inventory.FirstOrDefault(item => item is Drink) is Drink drink)
            {
                Player.thirstValue = Math.Min(Player.thirstValue + drink.ThirstRestore, 100);
                Form.Output($"You drink a {drink.Name}. Thirst: {Player.thirstValue}");
                RemoveItem(drink);
            }
            else
            {
                Form.Output("You don't have any drinks!");
            }
        }

        /// <summary>
        /// Consume a medicine item
        /// </summary>
        public void Heal()
        {
            if (Player.inventory.FirstOrDefault(item => item is Medicine) is Medicine medicine)
            {
                Player.healthValue = Math.Min(Player.healthValue + medicine.HealthRestore, 100);
                Form.Output($"You use a {medicine.Name}. Health: {Player.healthValue}");
                RemoveItem(medicine);
            }
            else
            {
                Form.Output("You don't have any medicine!");
            }
        }

        /// <summary>
        /// Rest (used to gain slight health)
        /// </summary>
        public void Rest()
        {
            Player.healthValue = Math.Min(Player.healthValue += rand.Next(31, 51), 100);
            Player.thirstValue = Math.Max(0, Player.thirstValue - rand.Next(31, 51));
            Player.hungerValue = Math.Max(0, Player.hungerValue - rand.Next(31, 51));
            Form.Output("You decide to rest for a few minutes.");
        }

        /// <summary>
        /// Decrease hunger and thirst
        /// </summary>
        public void Fatigue()
        {
            Player.thirstValue = Math.Max(0, Player.thirstValue - rand.Next(1, 10));
            Player.hungerValue = Math.Max(0, Player.hungerValue - rand.Next(1, 10));

            if (Player.hungerValue <= 0 || Player.thirstValue <= 0)
            {
                FatigueDamage();
            }
        }
        /// <summary>
        /// Applies damage if hunger and or thirst are 0
        /// </summary>
        public void FatigueDamage()
        {
            Player.healthValue = Math.Max(0, Player.healthValue - rand.Next(6, 10));

            if (Player.healthValue <= 0)
            {
                Form.GameOver();
            }
        }

        /// <summary>
        /// Can we add an item, true if we have space, false if not
        /// </summary>
        public bool CanAddItem(Item item)
        {
            return Player.currentWeightValue + item.Weight <= Player.maxWeightValue;
        }

        /// <summary>
        /// Add a single item to the players inventory
        /// </summary>
        public void AddItem(Item item)
        {
            if (!CanAddItem(item))
            {
                Form.Output("You can't carry any more items!");
                return;
            }

            var existingItem = Player.inventory.FirstOrDefault(i => i.Name == item.Name);

            if (existingItem != null && (item is not Weapon || (item is Weapon && existingItem.Id == item.Id)))
            {
                existingItem.Quantity++;
                Form.Output($"You find and pick up another {item.Name}! You now have: {existingItem.Quantity}");
            }
            else
            {
                Player.inventory.Add(item);
                Form.Output($"You find and pick up a {item.Name}! There was: {item.Quantity}");
            }

            Player.currentWeightValue += item.Weight * item.Quantity;
            UpdateInventory();
        }

        /// <summary>
        /// A method overload to add a list of items to the players inventory instead of a single one
        /// </summary>
        public void AddItem(List<Item> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        /// <summary>
        /// Refresh the inventory GUI
        /// </summary>
        public void UpdateInventory()
        {
            // Add columns 
            // They are always added trough code because they are not set in the designer
            if (Form.inventoryGrid.Columns.Count == 0)
            {
                var iconColumn = new DataGridViewImageColumn
                {
                    Name = "Icon",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                Form.inventoryGrid.Columns.Add(iconColumn);
                Form.inventoryGrid.Columns.Add("Name", "Name");
                Form.inventoryGrid.Columns.Add("Weight", "Weight");
                Form.inventoryGrid.Columns.Add("Quantity", "Quantity");
            }

            Form.inventoryGrid.Rows.Clear();

            foreach (var item in Player.inventory)
            {
                if (item == null)
                {
                    continue;
                }

                // Check if there's already a row for this item
                var existingRow = Form.inventoryGrid.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == item.Name && (item is not Weapon));

                if (existingRow != null)
                {
                    existingRow.Cells["Quantity"].Value = item.Quantity;
                }
                else
                {
                    var index = Form.inventoryGrid.Rows.Add();
                    var row = Form.inventoryGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(item.Icon);
                    row.Cells["Name"].Value = item.Name;
                    row.Cells["Weight"].Value = item.Weight;
                    row.Cells["Quantity"].Value = item.Quantity;
                    Player.itemDic[row] = item;
                }
            }
            Form.inventoryGrid.CellMouseEnter += InventoryGrid_CellMouseEnter;
        }

        // Weapon tooltip
        public void InventoryGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = Form.inventoryGrid.Rows[e.RowIndex];
            var item = Player.itemDic[row];

            if (item is not Weapon weapon)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ToolTipText = string.Empty;
                }
                return;
            }

            var tooltip = $"Damage: {weapon.Damage}\nDurability: {weapon.Durability}\nMelee: {weapon.Melee}\nID: {weapon.Id}";
            row.Cells[0].ToolTipText = tooltip;
        }

        /// <summary>
        /// Remove an item when its consumed.
        /// </summary>
        public void RemoveItem(Item item)
        {
            var existingItem = Player.inventory.FirstOrDefault(i => i.Name == item.Name);

            if (existingItem == null)
            {
                return;
            }

            if (Player.equippedItem != Guid.Empty && Player.equippedItem == item.Id)
            {
                Player.equippedItem = Guid.Empty;
            }

            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
            }
            else
            {
                Player.inventory.Remove(existingItem);
            }

            UpdateInventory();
        }

        /// <summary>
        /// Equip a Weapon type item
        /// </summary>
        // Should be modified to accept clothing too in the future
        public void EquipItem(string itemName)
        {
            var itemNameUpper = char.ToUpper(itemName[0]) + itemName.Substring(1);
            var item = Player.inventory
                .OfType<Weapon>()
                .Where(w => w.Name == itemNameUpper)
                .OrderByDescending(w => w.Durability)
                .FirstOrDefault();

            if (Player.equippedItem != Guid.Empty)
            {
                var currentlyEquippedWeapon = Player.inventory
                    .OfType<Weapon>()
                    .FirstOrDefault(w => w.Id == Player.equippedItem);
                if (currentlyEquippedWeapon != null)
                {
                    currentlyEquippedWeapon.Icon = Image.FromFile($"Assets/Images/Icons/{currentlyEquippedWeapon.Name}.png");
                }
            }

            if (item != null && item.Id == Player.equippedItem)
            {
                Form.Output("You already have this item equipped.");
            }
            else if (item != null)
            {
                Player.equippedItem = item.Id;
                item.Icon = Image.FromFile($"Assets/Images/Icons/Equipped/{item.Name}Equipped.png");
                Form.Output($"You have equipped a {item.Name}.");
            }
            else
            {
                Form.Output($"You do not have a {itemName} in your inventory.");
            }
            UpdateInventory();
        }
    }
}