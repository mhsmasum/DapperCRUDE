using DapperCRUDE.Data;
using DapperCRUDE.Models;

namespace DapperCRUDE.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDBContext _context;
        public CompanyRepositoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public Company Add(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return company;
        }

        public void Delete(int id)
        {
            Company? company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if(company != null)
            {
                _context.Remove(company);
            }
        }

        public Company FindById(int id)
        {

            Company? company = _context.Companies.FirstOrDefault(c=>c.Id==id);
            return company;
        }

        public ICollection<Company> GetAll()
        {
           return _context.Companies.ToList();
        }

        public Company Update(Company company)
        {
            _context.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
