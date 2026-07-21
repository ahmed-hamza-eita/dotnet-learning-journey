using DapperAspNetCore.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DapperAspNetCore.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        public async Task<ActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("{Id}", Name = "CompanyById")]
        public async Task<ActionResult> GetCompany(int Id)
        {
            var company = await _companyRepository.GetCompany(Id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }
    }
}
