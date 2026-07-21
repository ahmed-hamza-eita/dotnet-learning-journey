using DapperAspNetCore.Entities;

namespace DapperAspNetCore.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
