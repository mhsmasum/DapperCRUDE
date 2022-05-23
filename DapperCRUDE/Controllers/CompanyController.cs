using DapperCRUDE.Models;
using DapperCRUDE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(companyRepository.FindById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(companyRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            return Ok(companyRepository.Add(company));
        }

        [HttpPut]
        public IActionResult Put(Company company)
        {
            return Ok(companyRepository.Update(company));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            companyRepository.Delete(id);
            return Ok("success");
        }
    }
}
