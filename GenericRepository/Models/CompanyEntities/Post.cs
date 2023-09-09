namespace GenericRepository.Models.CompanyEntities
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> People { get; set; }
    }
}
