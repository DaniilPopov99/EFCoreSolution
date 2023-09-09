using GenericRepository.Contexts;
using GenericRepository.Repositories.Implementations;
using GenericRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UoW.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            var companiesConnectionString = configuration.GetConnectionString("CompaniesConnection");
            var organizationsConnectionString = configuration.GetConnectionString("OrganizationsConnection");

            services.AddCompaniesRepositories(companiesConnectionString);
            services.AddOrganizationsRepositories(organizationsConnectionString);

            return services;
        }

        private static IServiceCollection AddCompaniesRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompaniesContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web.API")));

            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPostsRepository, PostsRepository>();

            return services;
        }

        private static IServiceCollection AddOrganizationsRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OrganizationsContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web.API")));

            services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
            services.AddScoped<IAddressesRepository, AddressesRepository>();
            services.AddScoped<IEmailsRepository, EmailsRepository>();

            return services;
        }
    }
}
