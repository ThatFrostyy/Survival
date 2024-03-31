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
    public class Character
    {
        private readonly Random _rand = new();
        private readonly Form1 _form;
        private readonly Database _database;
        private readonly Tools _tools;

        #region Item Lists and Dictionaries 
        // Keeps track of all the picked up items and their gui's 
        public Dictionary<DataGridViewRow, Item> itemDic = [];
        // Inventory
        public List<Item> inventory = [];
        #endregion Item Lists and Dictionaries

        #region Skills 
        // Skills and levels
        public int xpValue = 0;
        public int levelValue = 1;
        public int strengthValue = 15;
        #endregion Skills

        #region Stats
        // Stats
        public int healthValue = 100;
        public int hungerValue = 100;
        public int thirstValue = 100;
        public int armorValue = 0;
        public double currentWeightValue = 0;
        public int maxWeightValue = 30;
        #endregion Stats

        #region Locations
        // Locations
        public string location = "Beach";
        public bool inCombat = false;
        public bool inShop = false;
        #endregion Locations

        #region Other
        // Other
        public Guid equippedItem;
        #endregion Other

        // Constructor
        public Character(Form1 form, Database database, Tools tools)
        {
            this._form = form;
            _database = database;
            _tools = tools;
        }

        #region Other
        /// <summary>
        /// Called on the game start, useful for adding items to the inventory, testing, etc
        /// </summary>
        public void OnPlayerCreate()
        {
        }
        #endregion Other

        #region Item Methods
        /// <summary>
        /// Eat an eatable item
        /// </summary>
        public void Eat(Command command)
        {
            var itemName = command.Argument;
            var itemToEat = inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase) && item is Food);

            if (itemToEat == null)
            {
                itemToEat = inventory.FirstOrDefault(item => item is Food);
                if (itemToEat == null)
                {
                    _form.Output("You don't have any food to eat!");
                    return;
                }
            }

            var food = itemToEat as Food;

            hungerValue = Math.Min(hungerValue + food.HungerRestore, 100);
            _form.Output($"You eat a {food.Name}. Hunger: {hungerValue}");
            _tools.PlaySound(@"./Assets/Sounds/Items/Food/Eat.wav");

            RemoveItem(food);
        }

        /// <summary>
        /// Drink a drink
        /// </summary>
        public void Drink(Command? command = null)
        {
            var itemName = command.Argument;
            var itemToDrink = inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase) && item is Drink);

            if (itemToDrink == null)
            {
                itemToDrink = inventory.FirstOrDefault(item => item is Drink);
                if (itemToDrink == null)
                {
                    _form.Output("You don't have any drinks to drink!");
                    return;
                }
            }

            var drink = itemToDrink as Drink;

            thirstValue = Math.Min(thirstValue + drink.ThirstRestore, 100);
            _form.Output($"You drink a {drink.Name}. Thirst: {thirstValue}");
            _tools.PlaySound(@"./Assets/Sounds/Items/Food/Drink.wav");

            RemoveItem(drink);
        }

        /// <summary>
        /// Consume a medicine item
        /// </summary>
        public void Heal(Command? command = null)
        {
            var itemName = command.Argument;
            var itemToUse = inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase) && item is Medicine);

            if (itemToUse == null)
            {
                itemToUse = inventory.FirstOrDefault(item => item is Medicine);
                if (itemToUse == null)
                {
                    _form.Output("You don't have any healing items to use!");
                    return;
                }
            }

            var medicine = itemToUse as Medicine;

            healthValue = Math.Min(healthValue + medicine.HealthRestore, 100);
            _form.Output($"You use a {medicine.Name}. Health: {healthValue}");
            _tools.PlaySound(@"./Assets/Sounds/Items/Misc/Heal.wav");

            RemoveItem(medicine);
        }

        /// <summary>
        /// Can we add an item, true if we have space, false if not
        /// </summary>
        public bool CanAddItem(Item item)
        {
            return currentWeightValue + item.Weight <= maxWeightValue;
        }

        /// <summary>
        /// Add a single item to the players inventory
        /// </summary>
        public void AddItem(Item item)
        {
            if (!CanAddItem(item))
            {
                _form.Output("You can't carry any more items!");
                return;
            }

            var existingItem = inventory.FirstOrDefault(i => i.Name == item.Name);

            if (existingItem != null && (item is not Weapon || (item is Weapon && existingItem.Id == item.Id)))
            {
                existingItem.Quantity++;
                _form.Output($"You find and pick up another {item.Name}! You now have: {existingItem.Quantity}");
            }
            else
            {
                inventory.Add(item);
                _form.Output($"You find and pick up a {item.Name}! There was: {item.Quantity}");
            }

            currentWeightValue += item.Weight * item.Quantity;
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
        /// Remove an item
        /// </summary>
        public void RemoveItem(Item item)
        {
            var existingItem = inventory.FirstOrDefault(i => i.Name == item.Name);

            if (existingItem == null)
            {
                return;
            }

            if (equippedItem != Guid.Empty && equippedItem == item.Id)
            {
                equippedItem = Guid.Empty;
            }

            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
            }
            else
            {
                inventory.Remove(existingItem);
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
            var item = inventory
                .OfType<Weapon>()
                .Where(w => w.Name == itemNameUpper)
                .OrderByDescending(w => w.Durability)
                .FirstOrDefault();

            if (equippedItem != Guid.Empty)
            {
                var currentlyEquippedWeapon = inventory
                    .OfType<Weapon>()
                    .FirstOrDefault(w => w.Id == equippedItem);
                if (currentlyEquippedWeapon != null)
                {
                    currentlyEquippedWeapon.Icon = Image.FromFile($"Assets/Images/Icons/{currentlyEquippedWeapon.Name}.png");
                }
            }

            if (item != null && item.Id == equippedItem)
            {
                _form.Output("You already have this item equipped.");
            }
            else if (item != null)
            {
                equippedItem = item.Id;
                item.Icon = Image.FromFile($"Assets/Images/Icons/Equipped/{item.Name}Equipped.png");
                _tools.PlaySound(string.Empty, item, false, true);

                _form.Output($"You have equipped a {item.Name}.");
            }
            else
            {
                _form.Output($"You do not have a {itemName} in your inventory.");
            }
            UpdateInventory();
        }
        #endregion Item Methods

        #region Player Methods
        /// <summary>
        /// Add random value xp to the player (1-10)
        /// </summary>
        public void AddXp()
        {
            var add = _rand.Next(1, 11);
            xpValue += add;

            if (xpValue >= 100)
            {
                levelValue++;
                xpValue = 0;
                _form.Output($"You have leveled up to level {levelValue}!");
            }

            _form.Output($"You gained {add} xp!");
        }

        /// <summary>
        /// Decrease hunger and thirst
        /// </summary>
        public void Fatigue()
        {
            thirstValue = Math.Max(0, thirstValue - _rand.Next(1, 10));
            hungerValue = Math.Max(0, hungerValue - _rand.Next(1, 10));

            if (hungerValue <= 0 || thirstValue <= 0)
            {
                FatigueDamage();
            }
        }

        /// <summary>
        /// Applies damage if hunger and or thirst are 0
        /// </summary>
        public void FatigueDamage()
        {
            healthValue = Math.Max(0, healthValue - _rand.Next(6, 10));

            if (healthValue <= 0)
            {
                _form.GameOver();
            }
        }

        /// <summary>
        /// Rest (used to gain slight health)
        /// </summary>
        public void Rest()
        {
            healthValue = Math.Min(healthValue += _rand.Next(31, 51), 100);
            thirstValue = Math.Max(0, thirstValue - _rand.Next(31, 51));
            hungerValue = Math.Max(0, hungerValue - _rand.Next(31, 51));
            _form.Output("You decide to rest for a few minutes.");
        }
        #endregion Player Methods

        #region Inventory
        /// <summary>
        /// Refresh the inventory GUI
        /// </summary>
        public void UpdateInventory()
        {
            // Add columns 
            // They are always added trough code because they are not set in the designer
            if (_form.inventoryGrid.Columns.Count == 0)
            {
                var iconColumn = new DataGridViewImageColumn
                {
                    Name = "Icon",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                _form.inventoryGrid.Columns.Add(iconColumn);
                _form.inventoryGrid.Columns.Add("Name", "Name");
                _form.inventoryGrid.Columns.Add("Weight", "Weight");
                _form.inventoryGrid.Columns.Add("Quantity", "Quantity");
            }

            _form.inventoryGrid.Rows.Clear();

            foreach (var item in inventory)
            {
                if (item == null)
                {
                    continue;
                }

                // Check if there's already a row for this item
                var existingRow = _form.inventoryGrid.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Name"].Value.ToString() == item.Name && (item is not Weapon));

                if (existingRow != null)
                {
                    existingRow.Cells["Quantity"].Value = item.Quantity;
                }
                else
                {
                    var index = _form.inventoryGrid.Rows.Add();
                    var row = _form.inventoryGrid.Rows[index];

                    row.Cells["Icon"].Value = new Bitmap(item.Icon);
                    row.Cells["Name"].Value = item.Name;
                    row.Cells["Weight"].Value = item.Weight;
                    row.Cells["Quantity"].Value = item.Quantity;
                    itemDic[row] = item;
                }
            }
            _form.inventoryGrid.CellMouseEnter += InventoryGrid_CellMouseEnter;
        }

        public void InventoryGrid_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _form.inventoryGrid.Rows[e.RowIndex];
            var item = itemDic[row];

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
        #endregion Inventory

        #region Item Creation
        public void CreateItem(string itemName, string? newName = null, double? newWeight = null, int? newQuantity = null, string? newIconPath = null, int? newStock = null, int? newPrice = null)
        {
            if (_database.items.TryGetValue(itemName, out Item? value))
            {
                if (value.GetType() == typeof(Item))
                {
                    var item = value.Clone();
                    item.Id = Guid.NewGuid();
                    if (newName != null) item.Name = newName;
                    if (newWeight != null) item.Weight = newWeight.Value;
                    if (newQuantity != null) item.Quantity = newQuantity.Value;
                    if (newIconPath != null) item.Icon = Image.FromFile(newIconPath);
                    if (newStock != null) item.Stock = newStock.Value;
                    if (newPrice != null) item.Price = newPrice.Value;

                    AddItem(item);
                }
            }
        }

        public void CreateWeapon(string itemName, string? newName = null, double? newWeight = null, int? newQuantity = null, string? newIconPath = null, int? newDamage = null, int? newDurability = null, bool? newIsMelee = null, int? newStock = null, int? newPrice = null)
        {
            if (_database.weapons.TryGetValue(itemName, out Item? value))
            {
                if (value.GetType() == typeof(Weapon))
                {
                    var weapon = (Weapon)value.Clone();
                    weapon.Id = Guid.NewGuid();
                    if (newName != null) weapon.Name = newName;
                    if (newWeight != null) weapon.Weight = newWeight.Value;
                    if (newQuantity != null) weapon.Quantity = newQuantity.Value;
                    if (newIconPath != null) weapon.Icon = Image.FromFile(newIconPath);
                    if (newDamage != null) weapon.Damage = newDamage.Value;
                    if (newDurability != null) weapon.Durability = newDurability.Value;
                    if (newIsMelee != null) weapon.Melee = newIsMelee.Value;
                    if (newStock != null) weapon.Stock = newStock.Value;
                    if (newPrice != null) weapon.Price = newPrice.Value;

                    AddItem(weapon);
                }
            }
        }

        public void CreateFood(string itemName, string? newName = null, double? newWeight = null, int? newQuantity = null, string? newIconPath = null, int? newHungerRestoration = null, int? newStock = null, int? newPrice = null)
        {
            if (_database.foods.TryGetValue(itemName, out Item? value))
            {
                if (value.GetType() == typeof(Food))
                {
                    var food = (Food)value.Clone();
                    food.Id = Guid.NewGuid();
                    if (newName != null) food.Name = newName;
                    if (newWeight != null) food.Weight = newWeight.Value;
                    if (newQuantity != null) food.Quantity = newQuantity.Value;
                    if (newIconPath != null) food.Icon = Image.FromFile(newIconPath);
                    if (newHungerRestoration != null) food.HungerRestore = newHungerRestoration.Value;
                    if (newStock != null) food.Stock = newStock.Value;
                    if (newPrice != null) food.Price = newPrice.Value;

                    AddItem(food);
                }
            }
        }

        public void CreateDrink(string itemName, string? newName = null, double? newWeight = null, int? newQuantity = null, string? newIconPath = null, int? newThirstRestoration = null, int? newStock = null, int? newPrice = null)
        {
            if (_database.drinks.TryGetValue(itemName, out Item? value))
            {
                if (value.GetType() == typeof(Drink))
                {
                    var drink = (Drink)value.Clone();
                    drink.Id = Guid.NewGuid();
                    if (newName != null) drink.Name = newName;
                    if (newWeight != null) drink.Weight = newWeight.Value;
                    if (newQuantity != null) drink.Quantity = newQuantity.Value;
                    if (newIconPath != null) drink.Icon = Image.FromFile(newIconPath);
                    if (newThirstRestoration != null) drink.ThirstRestore = newThirstRestoration.Value;
                    if (newStock != null) drink.Stock = newStock.Value;
                    if (newPrice != null) drink.Price = newPrice.Value;

                    AddItem(drink);
                }
            }
        }

        public void CreateMedicine(string itemName, string? newName = null, double? newWeight = null, int? newQuantity = null, string? newIconPath = null, int? newHealthRestoration = null, int? newStock = null, int? newPrice = null)
        {
            if (_database.medicines.TryGetValue(itemName, out Item? value))
            {
                if (value.GetType() == typeof(Medicine))
                {
                    var med = (Medicine)value.Clone();
                    med.Id = Guid.NewGuid();
                    if (newName != null) med.Name = newName;
                    if (newWeight != null) med.Weight = newWeight.Value;
                    if (newQuantity != null) med.Quantity = newQuantity.Value;
                    if (newIconPath != null) med.Icon = Image.FromFile(newIconPath);
                    if (newHealthRestoration != null) med.HealthRestore = newHealthRestoration.Value;
                    if (newStock != null) med.Stock = newStock.Value;
                    if (newPrice != null) med.Price = newPrice.Value;

                    AddItem(med);
                }
            }
        }
        #endregion Item Creation
    }
}