namespace ReflectionsTesting.Models
{
    public class Maker : Entity
    {
        public string Name { get; set; }

        public string Abbrv { get; set; }

        public Maker(int id, string abbrv, string name)
        {
            this.Id = id;
            this.Abbrv = abbrv;
            this.Name = name;
        }
    }
}
