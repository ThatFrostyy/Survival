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

namespace Items
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
        public Image Icon { get; set; }

        public Item(string name, int weight, int quantity, string iconPath)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
            Icon = Image.FromFile(iconPath);
        }
    }

    public class Food : Item
    {
        public int HungerRestore { get; set; }

        public Food(string name, int weight, int quantity, string iconPath, int hungerRestore) : base(name, weight, quantity, iconPath)
        {
            HungerRestore = hungerRestore;
        }
    }

    public class Drink : Item
    {
        public int ThirstRestore { get; set; }

        public Drink(string name, int weight, int quantity, string iconPath, int thirstRestore) : base(name, weight, quantity, iconPath)
        {
            ThirstRestore = thirstRestore;
        }
    }
}
