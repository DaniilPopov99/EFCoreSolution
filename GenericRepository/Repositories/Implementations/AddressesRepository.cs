using GenericRepository.Contexts;
using GenericRepository.Models.OrganizationEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class AddressesRepository : GenericRepository<Address, OrganizationsContext>, IAddressesRepository
    {
        public AddressesRepository(OrganizationsContext context) : base(context)
        {

        }
    }
}
