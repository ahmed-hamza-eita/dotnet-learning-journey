namespace DapperAspNetCore.Entities
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Position { set; get; }

        public Company Company { set; get; }
        public int CompanyId { set; get; }
    }
}
