
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

namespace Enemies
{
    public class Enemy
    {
        public Guid EntityId { get; private set; }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public bool IsBoss { get; set; }
        // Could consider adding an inventory, it would be a list of random items 
        // With a random chance from a list 

        public Enemy(string name, int health, int armor, int damage, bool isBoss)
        {
            EntityId = Guid.NewGuid();
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
            IsBoss = isBoss;
        }
    }
}
