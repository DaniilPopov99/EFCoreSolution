namespace UoW.Models.CompanyEntities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }

        public Company Company { get; set; }
        public List<Post> Posts { get; set; }
    }
}
