using GenericRepository.Contexts;
using GenericRepository.Models.OrganizationEntities;
using GenericRepository.Repositories.Interfaces;

namespace GenericRepository.Repositories.Implementations
{
    internal class EmailsRepository : GenericRepository<Email, OrganizationsContext>, IEmailsRepository
    {
        public EmailsRepository(OrganizationsContext context) : base(context)
        {

        }
    }
}
