namespace GenericRepository.Models.OrganizationEntities
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}
