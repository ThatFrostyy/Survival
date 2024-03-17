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
namespace Survival
{
    public class Shop
    {
        private readonly Random _rand = new();
        private readonly Form1 _form;
        private readonly Character _character;

        #region Shop Variables
        // Shop inventory
        public List<Item> items = [];
        #endregion Shop Variables

        // Constructor
        public Shop(Form1 form, Character character)
        {
            _form = form;
            _character = character;
        }

        #region Other
        /// <summary>
        /// Called on the game start, useful for adding items to the shop, testing, etc
        /// </summary>
        public void OnShopCreate()
        {
            Food apple = new("Apple", 1, 1, "Assets/Images/Icons/Apple.png", 15, stock: _rand.Next(1, 11), price: 15);
            Drink waterbottle = new("Water Bottle", 1, 1, "Assets/Images/Icons/WaterBottle.png", 30, stock: _rand.Next(1, 6), price: 20);
            Medicine bandage = new("Bandage", 0.2, 1, "Assets/Images/Icons/Bandage.png", 30, stock: _rand.Next(1, 6), price: 30);
            Weapon shotgun = new("Shotgun", 3, 1, "Assets/Images/Icons/Shotgun.png", 50, 100, false, 1, 600);
            items.Add(apple);
            items.Add(waterbottle);
            items.Add(bandage);
            items.Add(shotgun);
        }
        #endregion Other

        #region Shop Methods
        /// <summary>
        /// Used to buy an item from the shop, find the item using the argument from the command class (command.Argument)
        /// </summary>
        public void Buy(Command command)
        {
            var itemName = command.Argument;
            var itemToBuy = items.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));

            if (itemToBuy == null)
            {
                _form.Output($"Item {itemName} not found in the shop.");
                return;

            }

            if (!_character.CanAddItem(itemToBuy))
            {
                _form.Output("You can't carry any more items!");
                return;
            }

            if (itemToBuy.Stock < 1)
            {
                _form.Output($"Item {itemName} is out of stock.");
                return;
            }

            var playerMoney = _character.inventory.FirstOrDefault(item => item.Name == "Tender");

            if (playerMoney == null || playerMoney.Quantity < itemToBuy.Price)
            {
                _form.Output("You don't have enough money to buy this item.");
                return;
            }

            playerMoney.Quantity -= itemToBuy.Price;
            if (playerMoney.Quantity <= 0)
            {
                _character.RemoveItem(playerMoney);
            }

            itemToBuy.Stock--;

            var playerItem = _character.inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
            if (playerItem != null && (itemToBuy is not Weapon || (itemToBuy is Weapon && playerItem.Id == itemToBuy.Id)))
            {
                playerItem.Quantity++;
            }
            else
            {
                _character.inventory.Add(itemToBuy);
            }

            _form.Output($"You bought a {itemName} for the price of {itemToBuy.Price}.");
            _character.UpdateInventory();
        }

        /// <summary>
        /// Used to sell an item to the shop, find the item using the argument from the command class (command.Argument)
        /// </summary>
        public void Sell(Command command)
        {
            var itemName = command.Argument;
            var itemToSell = _character.inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));

            Item money = new("Tender", 0.1, itemToSell.Price / 2, "Assets/Images/Icons/Money.png");

            if (itemToSell == null)
            {
                _form.Output($"Item {itemName} not found in the inventory.");
                return;
            }

            if (!_character.CanAddItem(money))
            {
                _form.Output("You can't carry any more items!");
                return;
            }

            if (itemToSell.Quantity < 1)
            {
                _form.Output($"You don't have any {itemName}.");
                return;
            }

            var playerMoney = _character.inventory.FirstOrDefault(item => item.Name == "Tender");
            if (playerMoney != null)
            {
                playerMoney.Quantity += itemToSell.Price / 2;
                _character.RemoveItem(itemToSell);
            }
            else
            {
                _character.AddItem(money);
                _character.RemoveItem(itemToSell);
            }

            _form.Output($"You sold a {itemName} for {itemToSell.Price / 2} tender.");
            _character.UpdateInventory();
        }
        #endregion Shop Methods

        #region Shop GUI
        /// <summary>
        /// Called when the player buys an item, etc
        /// </summary>
        public void UpdateShop()
        {
            // Add columns 
            // They are always added trough code because they are not set in the designer
            if (_form.shopGrid.Columns.Count == 0)
            {
                var iconColumn = new DataGridViewImageColumn
                {
                    Name = "Icon",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                _form.shopGrid.Columns.Add(iconColumn);
                _form.shopGrid.Columns.Add("Name", "Name");
                _form.shopGrid.Columns.Add("Price", "Price");
                _form.shopGrid.Columns.Add("Stock", "Stock");
            }

            _form.shopGrid.Rows.Clear();

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                // Check if there's already a row for this item
                var existingRow = _form.shopGrid.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == item.Name);

                if (existingRow != null)
                {
                    existingRow.Cells["Stock"].Value = item.Stock;
                }
                else
                {
                    var index = _form.shopGrid.Rows.Add();
                    var row = _form.shopGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(item.Icon);
                    row.Cells["Name"].Value = item.Name;
                    row.Cells["Price"].Value = item.Price;
                    row.Cells["Stock"].Value = item.Stock;
                }
            }

            if (_character.inShop == false)
            {
                _form.Output("You enter the village shop.");
            }

            _form.shopGrid.CellMouseEnter += ShopGrid_CellMouseEnter;
        }

        public void ShopGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _form.shopGrid.Rows[e.RowIndex];
            var item = items.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());
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
                case Medicine med:
                    tooltip = $"Health Restore: {med.HealthRestore}\nWeight: {med.Weight}";
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
        #endregion Shop GUI
    }
}