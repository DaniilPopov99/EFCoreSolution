using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.CompanyEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class PostsRepository : GenericRepository<Post, CompaniesContext>, IPostsRepository
    {
        public PostsRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
