using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.OrganizationEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class OrganizationsRepository : GenericRepository<Organization, OrganizationsContext>, IOrganizationsRepository
    {
        public OrganizationsRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
