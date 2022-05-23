using DapperCRUDE.Models;

namespace DapperCRUDE.Repository
{
    public interface ICompanyRepository
    {
        Company FindById(int id);
        ICollection<Company> GetAll();
        Company Add(Company company);
        Company Update(Company company);
        void Delete(int id);
    }
}
