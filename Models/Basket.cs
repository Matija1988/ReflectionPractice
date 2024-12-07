
namespace ReflectionsTesting.Models
{
    public class Basket : Entity
    {
        public Guid UniqueId { get; set; }

        public DateTime DateOrdered { get; set; }

        public double Value { get; set; }

        public List<Item> BasketItems { get; set; }

        public Basket(int id, Guid uniqueId, List<Item> basketItems)
        {
            this.Id = id;
            this.UniqueId = uniqueId;
            this.DateOrdered = DateTime.Now;
            this.BasketItems = basketItems;
            this.Value = CalculateValue();
        }

        private double CalculateValue ()
        {
            double value = 0;

            foreach (var item in BasketItems) 
            {
                value += item.Price;
            }
            return value;

        }
    }
}
