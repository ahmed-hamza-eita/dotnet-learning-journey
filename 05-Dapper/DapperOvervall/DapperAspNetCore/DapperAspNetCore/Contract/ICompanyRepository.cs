using DapperAspNetCore.DTO;
using DapperAspNetCore.Entities;

namespace DapperAspNetCore.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int Id);
        public Task<Company> CreateCompany(CompanyForCreationDto compantDto);
        public Task UpdateCompany(int Id, CompanyForUpdateDto updateCompanyDto);
        public Task DeleteCompany(int Id);
        public Task<Company> GetCompanyByEmployeeId(int Id);
        public Task<Company> GetCompanyWithItsEmployees(int Id);

        public Task<List<Company>> MultiMapping();
    }
}
