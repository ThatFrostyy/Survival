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
using Player;
using Survival;
namespace Shop
{
    public class ShopCore
    {
        public List<Item> items = [];
    }

    public class ShopMethods
    {
        // I don't know how any of this works, but it does
        Random rand = new();
        public ShopCore Shop { get; }
        public Form1 Form { get; }
        public Character Player { get; }
        public CharacterMethods PlayerMethods { get; }

        public ShopMethods(ShopCore shop, Form1 form, Character player, CharacterMethods playerMethods) // Modify this
        {
            Shop = shop;
            Form = form;
            Player = player;
            PlayerMethods = playerMethods;
        }

        /// <summary>
        /// Called on the game start, useful for adding items to the shop, testing, etc
        /// </summary>
        public void OnShopCreate()
        {
            Food apple = new("Apple", 1, 1, "Assets/Images/Icons/Apple.png", 15, stock: rand.Next(1, 11), price: 12);
            Drink waterbottle = new("Water Bottle", 1, 1, "Assets/Images/Icons/WaterBottle.png", 30, stock: rand.Next(1,6), price: 20);
            Medicine bandage = new("Bandage", 0.2, 1, "Assets/Images/Icons/Bandage.png", 30, stock: rand.Next(1, 6), price: 30);
            Shop.items.Add(apple);
            Shop.items.Add(waterbottle);
            Shop.items.Add(bandage);
        }

        /// <summary>
        /// Called when the player buys an item, etc
        /// </summary>
        public void UpdateShop()
        {
            // Add columns 
            // They are always added trough code because they are not set in the designer
            if (Form.shopGrid.Columns.Count == 0)
            {
                var iconColumn = new DataGridViewImageColumn
                {
                    Name = "Icon",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                Form.shopGrid.Columns.Add(iconColumn);
                Form.shopGrid.Columns.Add("Name", "Name");
                Form.shopGrid.Columns.Add("Price", "Price");
                Form.shopGrid.Columns.Add("Stock", "Stock");
            }

            Form.shopGrid.Rows.Clear();

            foreach (var item in Shop.items)
            {
                if (item == null)
                {
                    continue;
                }

                // Check if there's already a row for this item
                var existingRow = Form.shopGrid.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == item.Name);

                if (existingRow != null)
                {
                    existingRow.Cells["Stock"].Value = item.Stock;
                }
                else
                {
                    var index = Form.shopGrid.Rows.Add();
                    var row = Form.shopGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(item.Icon);
                    row.Cells["Name"].Value = item.Name;
                    row.Cells["Price"].Value = item.Price;
                    row.Cells["Stock"].Value = item.Stock;
                }
            }

            if (Player.inShop == false)
            {
                Form.Output("You enter the village shop.");
            }

            Form.shopGrid.CellMouseEnter += ShopGrid_CellMouseEnter;
        }

        /// <summary>
        /// Used to buy an item from the shop, find the item using the argument from the command class (command.Argument)
        /// </summary>
        public void Buy(Command command)
        {
            var itemName = command.Argument;
            var itemToBuy = Shop.items.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));

            if (itemToBuy == null)
            {
                Form.Output($"Item {itemName} not found in the shop.");
                return;

            }

            if (itemToBuy.Stock < 1)
            {
                Form.Output($"Item {itemName} is out of stock.");
                return;
            }

            var playerMoney = Player.inventory.FirstOrDefault(item => item.Name == "Tender");

            if (playerMoney == null || playerMoney.Quantity < itemToBuy.Price)
            {
                Form.Output("You don't have enough money to buy this item.");
                return;
            }

            playerMoney.Quantity -= itemToBuy.Price;
            itemToBuy.Stock--;

            var playerItem = Player.inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
            if (playerItem != null)
            {
                playerItem.Quantity++;
            }
            else
            {
                Player.inventory.Add(itemToBuy);
            }

            Form.Output($"You bought a {itemName} for the price of {itemToBuy.Price}.");
            PlayerMethods.UpdateInventory();
        }

        /// <summary>
        /// Used to sell an item to the shop, find the item using the argument from the command class (command.Argument)
        /// </summary>
        public void Sell(Command command)
        {
            var itemName = command.Argument;
            var itemToSell = Player.inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
            var moneyGain = rand.Next(11, 31);

            if (itemToSell == null)
            {
                Form.Output($"Item {itemName} not found in the inventory.");
                return;
            }

            if (itemToSell.Quantity < 1)
            {
                Form.Output($"You don't have any {itemName}.");
                return;
            }

            var playerMoney = Player.inventory.FirstOrDefault(item => item.Name == "Tender");
            if (playerMoney != null)
            {
                playerMoney.Quantity += moneyGain;
                PlayerMethods.RemoveItem(itemToSell);
            }
            else
            {
                Item item = new("Tender", 0.1, moneyGain, "Assets/Images/Icons/Money.png");
                PlayerMethods.AddItem(item);
                PlayerMethods.RemoveItem(itemToSell);
            }

            Form.Output($"You sold a {itemName} for {moneyGain} tender.");
            PlayerMethods.UpdateInventory();
        }

        // Shop item tooltip
        public void ShopGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = Form.shopGrid.Rows[e.RowIndex];
            var item = Shop.items.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());
            var tooltip = string.Empty;

            switch (item)
            {
                case Weapon weapon:
                    tooltip = $"Damage: {weapon.Damage}\nDurability: {weapon.Durability}\nMelee: {weapon.Melee}";
                    break;
                case Food food:
                    tooltip = $"Hunger Restore: {food.HungerRestore}\nWeight: {food.Weight}";
                    break;
                case Drink drink:
                    tooltip = $"Thirst Restore: {drink.ThirstRestore}\nWeight: {drink.Weight}";
                    break;
                default:
                    tooltip = "Unknown item type";
                    break;
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ToolTipText = tooltip;
            }
        }
    }
}
