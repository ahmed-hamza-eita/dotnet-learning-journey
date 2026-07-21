using Dapper;
using DapperAspNetCore.Context;
using DapperAspNetCore.Contract;
using DapperAspNetCore.DTO;
using DapperAspNetCore.Entities;
using System.Data;

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

        public async Task DeleteCompany(int Id)
        {
            var query = @"Delete From Companies Where Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id });
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

        public async Task<Company> GetCompanyByEmployeeId(int Id)
        {
            string storedProcedureName = "ShowCompanyByEmployeeId";
            var parametres = new DynamicParameters();
            parametres.Add("Id", Id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(
                    storedProcedureName, parametres, commandType: CommandType.StoredProcedure);

                return company;
            }
        }

        public async Task<Company> GetCompanyWithItsEmployees(int Id)
        {
            var query = @"Select * From Companies Where Id = @Id
                          Select * From Employees Where CompanyId = @Id";

            using (var connection = _context.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync(query, new { Id }))
                {
                    var company = await multi.ReadSingleOrDefaultAsync<Company>();
                    if (company is not null)
                        company.Employees = (await multi.ReadAsync<Employee>()).ToList();

                    return company;
                }
            }
        }

        public async Task<List<Company>> MultiMapping()
        {
            var query = @"Select * From Companies c JOIN Employees e ON c.Id = e.CompanyId";
            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, Company>();
                var companies = await connection.QueryAsync<Company, Employee, Company>(
                    query, (company, employee) =>
                    {
                        if (!companyDict.TryGetValue(company.Id, out var currentCompany))
                        {
                            currentCompany = company;
                            companyDict.Add(currentCompany.Id, currentCompany);
                        }
                        currentCompany.Employees.Add(employee);
                        return currentCompany;
                    }

                    );
                return companyDict.Values.ToList();
            }
        }

        public async Task UpdateCompany(int Id, CompanyForUpdateDto updateCompanyDto)
        {
            var query = @"Update Companies Set Name = @Name, Address = @Address, Country = @Country 
                           Where Id =@Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", Id, System.Data.DbType.Int32);
            parameters.Add("Name", updateCompanyDto.Name, System.Data.DbType.String);
            parameters.Add("Address", updateCompanyDto.Address, System.Data.DbType.String);
            parameters.Add("Country", updateCompanyDto.Country, System.Data.DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
