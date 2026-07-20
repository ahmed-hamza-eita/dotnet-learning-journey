using DapperAspNetCore.Context;
using DapperAspNetCore.Contract;

namespace DapperAspNetCore.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;
    }
}
