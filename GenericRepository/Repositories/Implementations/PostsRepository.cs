using GenericRepository.Contexts;
using GenericRepository.Models.CompanyEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class PostsRepository : GenericRepository<Post, CompaniesContext>, IPostsRepository
    {
        public PostsRepository(CompaniesContext context) : base(context)
        {

        }
    }
}
