using Microsoft.AspNetCore.Mvc;
using UoW.Contexts;
using UoW.Interfaces;
using UoW.Models.CompanyEntities;
using UoW.Models.OrganizationEntities;
using UoW.Repositories.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly ICompaniesRepository _companiesRepository;
        private readonly IAddressesRepository _addressesRepository;

        private readonly CompaniesContext _companiesContext;
        private readonly OrganizationsContext _organizationsContext;

        public CompanyController(IUnitOfWorkFactory unitOfWorkFactory,
            ICompaniesRepository companiesRepository,
            IAddressesRepository addressesRepository,
            CompaniesContext companiesContext,
            OrganizationsContext organizationsContext)
        {

            _unitOfWorkFactory = unitOfWorkFactory;

            _companiesRepository = companiesRepository;
            _addressesRepository = addressesRepository;

            _companiesContext = companiesContext;
            _organizationsContext = organizationsContext;
        }

        #region Post

        [HttpPost(nameof(Create) + "/{id}")]
        public async Task<IActionResult> Create([FromRoute] int id)
        {
            using var companiesUoW = _unitOfWorkFactory.Create(_companiesContext);
            using var organizationsUoW = _unitOfWorkFactory.Create(_organizationsContext);

            var a = new Company
            {
                Name = $"New{id}"
            };

            var b = new Address
            {
                Name = $"New{id}"
            };

            _companiesRepository.Add(a);
            _addressesRepository.Add(b);

            companiesUoW.SaveChanges();
            organizationsUoW.SaveChanges();

            var all1 = _companiesRepository.GetAll();
            var all2 = _addressesRepository.GetAll();

            return Ok();
        }

        #endregion
    }
}
