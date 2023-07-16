using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UoW.Contexts;
using UoW.Implementations;
using UoW.Interfaces;
using UoW.Repositories.Implementations;
using UoW.Repositories.Interfaces;

namespace UoW.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompaniesRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompaniesContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web.API")));

            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPostsRepository, PostsRepository>();

            return services;
        }

        public static IServiceCollection AddOrganizationsRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OrganizationsContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web.API")));

            services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
            services.AddScoped<IAddressesRepository, AddressesRepository>();
            services.AddScoped<IEmailsRepository, EmailsRepository>();

            return services;
        }

        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IAmbientUnitOfWork, AmbientUnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            
            return services;
        }
    }
}
