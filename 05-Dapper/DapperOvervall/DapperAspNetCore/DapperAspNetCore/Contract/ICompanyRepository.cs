using DapperAspNetCore.DTO;
using DapperAspNetCore.Entities;

namespace DapperAspNetCore.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int Id);
        public Task<Company> CreateCompany(CompanyForCreationDto compantDto);
    }
}
