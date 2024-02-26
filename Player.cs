/*  <A text based survival game.>
    Copyright (C) <2024> <ThatFrostyy>

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
        // Inventory
        public List<Item> inventory = [];

        // Stats
        public int healthValue = 100;
        public int hungerValue = 100;
        public int thirstValue = 100;
        public double currentWeightValue = 0;
        public int maxWeightValue = 30;
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

        // Can we add an item, true if we have space, false if not
        public bool CanAddItem(Item item)
        {
            return Player.currentWeightValue + item.Weight <= Player.maxWeightValue;
        }

        // Add an item
        public void AddItem(Item item)
        {
            if (!CanAddItem(item))
            {
                Form.Output("You can't carry any more items!");
                return;
            }

            var existingItem = Player.inventory.FirstOrDefault(i => i.Name == item.Name);

            if (existingItem != null)
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

        // Update the inventory UI
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
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == item.Name);

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
                }
            }
            Form.inventoryGrid.CellMouseEnter += InventoryGrid_CellMouseEnter;
        }

        public void InventoryGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = Form.inventoryGrid.Rows[e.RowIndex];
            var item = Player.inventory.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());

            if (item is not Weapon weapon)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ToolTipText = string.Empty;
                }
                return;
            }

            var tooltip = $"Damage: {weapon.Damage}\nDurability: {weapon.Durability}\nMelee: {weapon.Melee}";
            row.Cells[0].ToolTipText = tooltip;
        }
    }
}