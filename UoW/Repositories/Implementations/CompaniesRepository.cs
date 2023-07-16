using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.CompanyEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class CompaniesRepository : GenericRepository<Company, CompaniesContext>, ICompaniesRepository
    {
        public CompaniesRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
