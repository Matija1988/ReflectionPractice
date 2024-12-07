using ReflectionsTesting.Models;
using ReportingReflection;


namespace ReflectionsTesting
{
    internal class Main
    {
        public DataSeed _dataSeed { get; }
        public Main()
        {
            _dataSeed = new DataSeed();
        }


        public void Reflection()
        {
            new CSVGenerator<Book>(BookData.Books, "Boks").Generate();
            new CSVGenerator<Car>(_dataSeed._cars, "Cars").Generate();
            new CSVGenerator<Basket>(_dataSeed._basket, "Basket").Generate();
        }
    }
}
