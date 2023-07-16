using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.CompanyEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class PeopleRepository : GenericRepository<Person, CompaniesContext>, IPeopleRepository
    {
        public PeopleRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
