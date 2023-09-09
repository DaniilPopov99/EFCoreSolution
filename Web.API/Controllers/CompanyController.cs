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

        public CompanyController(
            ICompaniesRepository companiesRepository,
            IAddressesRepository addressesRepository)
        {
            _companiesRepository = companiesRepository;
            _addressesRepository = addressesRepository;
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

            _companiesRepository.Add(a);
            await _companiesRepository.SaveChangesAsync(false);
            var all1 = _companiesRepository.GetAll();

            _companiesRepository.Add(b);
            await _companiesRepository.SaveChangesAsync(false);
            var all2 = _companiesRepository.GetAll();

            _companiesRepository.Add(c);
            await _companiesRepository.SaveChangesAsync();
            var all3 = _companiesRepository.GetAll();

            return Ok();
        }

        #endregion
    }
}
