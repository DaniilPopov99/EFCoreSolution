using GenericRepository.Contexts;
using GenericRepository.Models.CompanyEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class PeopleRepository : GenericRepository<Person, CompaniesContext>, IPeopleRepository
    {
        public PeopleRepository(CompaniesContext context) : base(context)
        {

        }
    }
}
