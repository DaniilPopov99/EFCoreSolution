using GenericRepository.Contexts;
using GenericRepository.Models.CompanyEntities;
using GenericRepository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IAddressesRepository _addressesRepository;

        private readonly CompaniesContext _companiesContext;

        public CompanyController(
            ICompaniesRepository companiesRepository,
            IAddressesRepository addressesRepository,
            CompaniesContext companiesContext)
        {
            _companiesRepository = companiesRepository;
            _addressesRepository = addressesRepository;
            _companiesContext = companiesContext;
        }

        #region Post

        [HttpPost(nameof(Create) + "/{id}")]
        public async Task<IActionResult> Create([FromRoute] int id)
        {
            var a = new Company
            {
                Name = $"New{id}"
            };

            id++;

            var b = new Company
            {
                Name = $"New{id}"
            };

            id++;

            var c = new Company
            {
                Name = $"New{id}"
            };

            using var transaction = _companiesContext.Database.BeginTransaction();

            try
            {
                _companiesRepository.Add(a);
                await _companiesRepository.SaveChangesAsync();

                var all = _companiesRepository.GetAll();
                var last1 = all.OrderBy(o => o.Id).Last();

                _companiesRepository.Add(b);
                await _companiesRepository.SaveChangesAsync();

                var last2 = all.OrderBy(o => o.Id).Last();

                _companiesRepository.Add(c);
                await _companiesRepository.SaveChangesAsync();

                var last3 = all.OrderBy(o => o.Id).Last();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }

            return Ok();
        }

        #endregion
    }
}
