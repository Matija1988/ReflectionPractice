namespace ReflectionsTesting.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
