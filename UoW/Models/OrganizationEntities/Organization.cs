namespace UoW.Models.OrganizationEntities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? AddressId { get; set; }

        public Address Address { get; set; }
        public List<Email> Emails { get; set; }
    }
}
