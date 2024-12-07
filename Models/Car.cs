namespace ReflectionsTesting.Models
{
    public class Car : Entity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Maker Maker { get; set; }

        public Car(int id, string name, double price, Maker maker)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Maker = maker;
        }

    }
}
