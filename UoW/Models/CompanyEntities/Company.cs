namespace UoW.Models.CompanyEntities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> People { get; set; }
    }
}
