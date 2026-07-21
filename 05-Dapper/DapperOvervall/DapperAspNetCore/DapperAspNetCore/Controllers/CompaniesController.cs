using DapperAspNetCore.Contract;
using DapperAspNetCore.DTO;
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

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyForCreationDto companyDto)
        {
            var createdCompany = await _companyRepository.CreateCompany(companyDto);

            return CreatedAtRoute(
                "CompanyById"
                , new { Id = createdCompany.Id }
                , createdCompany);

        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCompany(int Id, [FromBody] CompanyForUpdateDto updateCompanyDto)
        {
            var checkCompanyExisting = await _companyRepository.GetCompany(Id);
            if (checkCompanyExisting is null)
                return NotFound();

            await _companyRepository.UpdateCompany(Id, updateCompanyDto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCompany(int Id)
        {
            var checkCompanyExisting = await _companyRepository.GetCompany(Id);
            if (checkCompanyExisting is null)
                return NotFound();

            await _companyRepository.DeleteCompany(Id);
            return NoContent();
        }

        [HttpGet("CompanyByEmployeeId/{Id}")]
        public async Task<ActionResult> GetCompanyByEmployeeId(int Id)
        {
            var company = await _companyRepository.GetCompanyByEmployeeId(Id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("CompanyWithItsEmployees/{Id}")]
        public async Task<ActionResult> GetCompanyWithItsEmployees(int Id)
        {
            var company = await _companyRepository.GetCompanyWithItsEmployees(Id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("MultiMapping")]
        public async Task<ActionResult> MultiMapping()
        {
            var companies = await _companyRepository.MultiMapping();
            if (companies is null)
                return NotFound();

            return Ok(companies);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult> CreateCompany(List<CompanyForCreationDto> companiesDto)
        {
            try
            {
                await _companyRepository.CreateMultiCompanies(companiesDto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}