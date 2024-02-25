namespace Items
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }


        public Item(string name, int weight, int quantity)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
        }
    }

    public class Food : Item
    {
        public int HungerRestore { get; set; }

        public Food(string name, int weight, int quantity, int hungerRestore) : base(name, weight, quantity)
        {
            HungerRestore = hungerRestore;
        }
    }

    public class Drink : Item
    {
        public int ThirstRestore { get; set; }

        public Drink(string name, int weight, int quantity, int thirstRestore) : base(name, weight, quantity)
        {
            ThirstRestore = thirstRestore;
        }
    }
}
