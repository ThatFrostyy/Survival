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


// Ignore Spelling: Melee

namespace Items
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        public Image Icon { get; set; }

        public Item(string name, double weight, int quantity, string iconPath)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
            Icon = Image.FromFile(iconPath);
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        public bool Melee { get; set; }

        public Weapon(string name, double weight, int quantity, string iconPath, int damage, int durability, bool melee) : base(name, weight, quantity, iconPath)
        {
            Damage = damage;
            Durability = durability;
            Melee = melee;
        }
    }

    public class Food : Item
    {
        public int HungerRestore { get; set; }

        public Food(string name, double weight, int quantity, string iconPath, int hungerRestore) : base(name, weight, quantity, iconPath)
        {
            HungerRestore = hungerRestore;
        }
    }

    public class Drink : Item
    {
        public int ThirstRestore { get; set; }

        public Drink(string name, double weight, int quantity, string iconPath, int thirstRestore) : base(name, weight, quantity, iconPath)
        {
            ThirstRestore = thirstRestore;
        }
    }
}