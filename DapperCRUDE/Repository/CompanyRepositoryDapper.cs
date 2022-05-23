using Dapper;
using DapperCRUDE.Data;
using DapperCRUDE.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperCRUDE.Repository
{
    public class CompanyRepositoryDapper : ICompanyRepository, IDisposable
    {
        private IDbConnection db;
        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            var query = "insert into companies values(@name, @address , @website);" + " select SCOPE_IDENTITY()";

            var id = db.Query<int>(query, new
            {
                company.Name,
                company.Address,
                company.Website
            }
            ).Single();
            company.Id = id;
            return company;

        }

        public void Delete(int id)
        {
            var query = "delete from companies where id=@id";
            var exe = db.Execute(query, new { @id = id });
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Company FindById(int id)
        {
            var query = "Select * from Companies where id = @id";

            return db.Query<Company>(query, new { @id = id }).SingleOrDefault();
        }

        public ICollection<Company> GetAll()
        {
            var query = "Select * from Companies";
            return db.Query<Company>(query).ToList();
        }

        public Company Update(Company company)
        {
            var query = "Update companies set name=@name , address=@address , website = @website where id = @id";
            var re =  db.Execute(query, company);
            return company;
        }
    }
}
