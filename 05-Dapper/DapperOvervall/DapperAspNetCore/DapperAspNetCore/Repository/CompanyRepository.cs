using Dapper;
using DapperAspNetCore.Context;
using DapperAspNetCore.Contract;
using DapperAspNetCore.DTO;
using DapperAspNetCore.Entities;

namespace DapperAspNetCore.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<Company> CreateCompany(CompanyForCreationDto compantDto)
        {

            var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameter = new DynamicParameters();
            parameter.Add("Name", compantDto.Name, System.Data.DbType.String);
            parameter.Add("Address", compantDto.Address, System.Data.DbType.String);
            parameter.Add("Country", compantDto.Country, System.Data.DbType.String);

            using (var connection = _context.CreateConnection())
            {

                var Id = await connection.QuerySingleAsync<int>(query, parameter);
                var createdCompany = new Company
                {
                    Id = Id,
                    Name = compantDto.Name,
                    Address = compantDto.Address,
                    Country = compantDto.Country
                };
                return createdCompany;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = @"Select * from Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompany(int Id)
        {
            var query = @"Select * From Companies Where Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { Id });
                return company;
            }
        }
    }
}
