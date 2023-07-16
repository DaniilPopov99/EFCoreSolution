using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.OrganizationEntities;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class EmailsRepository : GenericRepository<Email, OrganizationsContext>, IEmailsRepository
    {
        public EmailsRepository(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {

        }
    }
}
