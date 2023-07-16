using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.OrganizationEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class AddressesRepository : GenericRepository<Address, OrganizationsContext>, IAddressesRepository
    {
        public AddressesRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
