namespace ReflectionsTesting.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Item(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
