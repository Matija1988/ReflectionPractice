using ReflectionsTesting.Models;

namespace ReflectionsTesting
{
    internal class DataSeed
    {
        public  List<Car> _cars { get; set; }
        public List<Maker> _makers { get; set; }

        public List<Item> _items { get; set; }

        public List<Basket> _basket { get; set; }

        private Main _main {  get; }

        public DataSeed(Main main) : this()
        {
            _main = main;
        }

        public DataSeed()
        {
            _cars = new List<Car>();
            _makers = new List<Maker>();
            _items = new List<Item>();
            _basket = new List<Basket>();

            FillMakers();
            FillCars();
            FillItems();
            FillBasket();

        }

        private void FillItems()
        {
            _items.Add(new Item(1, "Nvidia 4090", 1500.75));
            _items.Add(new Item(2, "Kingston 3444 MHZ 32GB 2x16GB", 300.41));
            _items.Add(new Item(3, "Toilet paper", 2.37));
            _items.Add(new Item(4, "Bread", 1.55));
            _items.Add(new Item(5, "Milk", 0.99));
        }

        private void FillBasket()
        {
            var itemsForBasket1 = new List<Item>();
            itemsForBasket1.Add(_items[0]);
            itemsForBasket1.Add(_items[1]);
            
            _basket.Add(new Basket(1, Guid.NewGuid(), itemsForBasket1));

            var itemsForBasket2 = new List<Item>();
            itemsForBasket2.Add(_items[2]);
            itemsForBasket2.Add(_items[3]);
            itemsForBasket2.Add(_items[4]);

            _basket.Add(new Basket(2, Guid.NewGuid(), itemsForBasket2));
        }

        private void FillCars()
        {
            _cars.Add(new Car(1, "MX-5", 3000.50, _makers[0]));
            _cars.Add(new Car(2, "MX-30", 5000.50, _makers[0]));
            _cars.Add(new Car(3, "CX-3", 31000.50, _makers[0]));
            _cars.Add(new Car(4, "CX-30", 39000.50, _makers[0]));
            _cars.Add(new Car(5, "CX-8", 20030.50, _makers[0]));
            _cars.Add(new Car(6, "iX M60", 30700.50, _makers[1]));
            _cars.Add(new Car(7, "BMW i7", 23000.50, _makers[1]));
            _cars.Add(new Car(8, "BMW i5", 13000.50, _makers[1]));
        }

        private void FillMakers ()
        {
            _makers.Add(new Maker(1, "Mazda", "Mazda Motor Corporation"));
            _makers.Add(new Maker(2, "BMW", "Bayerische Motoren Werke GmbH"));
        }
    }
}
