namespace DapperAspNetCore.Entities
{
    public class Company
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Country { set; get; }

        public List<Employee> Employees { set; get; } = new();
    }
}
