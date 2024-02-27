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
using Survival;
namespace Shop
{
    public class ShopCore
    {
        public List<Item> items = [];
    }

    public class ShopMethods
    {
        Random rand = new();

        public ShopCore Shop { get; }
        public Form1 Form { get; }

        public ShopMethods(ShopCore shop, Form1 form)
        {
            Shop = shop;
            Form = form;
        }

        public void OnShopCreate()
        {
            var numberOfApples = rand.Next(1, 11);

            Food apple = new("Apple", 1, 1, "Assets/Images/Apple.png", 15, stock: numberOfApples, price: 10);
            Shop.items.Add(apple);
        }

        public void UpdateShop()
        {
            // Add columns 
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
            Form.shopGrid.CellMouseEnter += ShopGrid_CellMouseEnter;
        }

        public void ShopGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = Form.shopGrid.Rows[e.RowIndex];
            var item = Shop.items.FirstOrDefault(i => i.Name == row.Cells["Name"].Value.ToString());

            var tooltip = string.Empty;

            // TO DO
            // Convert to switch statement
            if (item is Weapon weapon)
            {
                tooltip = $"Damage: {weapon.Damage}\nDurability: {weapon.Durability}\nMelee: {weapon.Melee}";
            }
            else if (item is Food food)
            {
                tooltip = $"Hunger Restore: {food.HungerRestore}\nWeight: {food.Weight}";
            }
            else if (item is Drink drink)
            {
                tooltip = $"Thirst Restore: {drink.ThirstRestore}\nWeight: {drink.Weight}";
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ToolTipText = tooltip;
            }
        }

    }
}
