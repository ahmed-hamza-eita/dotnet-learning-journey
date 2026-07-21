using Dapper;
using DapperAspNetCore.Context;
using DapperAspNetCore.Contract;
using DapperAspNetCore.Entities;

namespace DapperAspNetCore.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = @"Select * from Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
    }
}
