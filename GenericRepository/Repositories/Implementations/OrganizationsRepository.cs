using GenericRepository.Contexts;
using GenericRepository.Models.OrganizationEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class OrganizationsRepository : GenericRepository<Organization, OrganizationsContext>, IOrganizationsRepository
    {
        public OrganizationsRepository(OrganizationsContext context) : base(context)
        {

        }
    }
}
