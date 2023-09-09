using GenericRepository.Contexts;
using GenericRepository.Models.CompanyEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class CompaniesRepository : GenericRepository<Company, CompaniesContext>, ICompaniesRepository
    {
        public CompaniesRepository(CompaniesContext context) : base(context)
        {

        }
    }
}
