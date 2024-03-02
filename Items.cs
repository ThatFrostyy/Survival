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
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        public Image Icon { get; set; }
        public int Stock { get; set; } // Optional parameter for stock
        public double Price { get; set; } // Optional parameter for price

        public Item(string name, double weight, int quantity, string iconPath, int stock = 0, double price = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
            Quantity = quantity;
            Icon = Image.FromFile(iconPath);
            Stock = stock;
            Price = price;
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        public bool Melee { get; set; }

        public Weapon(string name, double weight, int quantity, string iconPath, int damage, int durability, bool melee, int stock = 0, double price = 0)
            : base(name, weight, quantity, iconPath, stock, price)
        {
            Damage = damage;
            Durability = durability;
            Melee = melee;
        }
    }

    public class Food : Item
    {
        public int HungerRestore { get; set; }

        public Food(string name, double weight, int quantity, string iconPath, int hungerRestore, int stock = 0, double price = 0)
            : base(name, weight, quantity, iconPath, stock, price)
        {
            HungerRestore = hungerRestore;
        }
    }

    public class Drink : Item
    {
        public int ThirstRestore { get; set; }

        public Drink(string name, double weight, int quantity, string iconPath, int thirstRestore, int stock = 0, double price = 0)
            : base(name, weight, quantity, iconPath, stock, price)
        {
            ThirstRestore = thirstRestore;
        }
    }

    public class Medicine : Item
    {
        public int HealthRestore { get; set; }

        public Medicine(string name, double weight, int quantity, string iconPath, int healthRestore, int stock = 0, double price = 0)
            : base(name, weight, quantity, iconPath, stock, price)
        {
            HealthRestore = healthRestore;
        }
    }
}
