namespace PestKitOnionAB104.Domain.Entities
{
    public class Department:BaseNameableEntity
    {
        public ICollection<Employee>? Employees { get; set; }
    }
}
