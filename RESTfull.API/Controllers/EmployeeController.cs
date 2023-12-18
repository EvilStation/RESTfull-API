using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.DTO;
using RESTfull.Infrastructure.Data;
using RESTfull.Infrastructure.Repository;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(Context context)
        {
            _employeeRepository = new EmployeeRepository(context);
        }
        // GET: api/Employee
        [HttpGet]
        public async Task<List<EmployeeDTO>> Get()
        {
            return await _employeeRepository.GetEmploeyersListAsync();
        }
        // DELETE api/Employee/3ee0decc-03eb-4d3c-4157-08dbfc1fbe75
        [HttpDelete("{id}")]
        public async Task Delete(String id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }
        // POST api/Employee
        [HttpPost]
        public async Task Post([FromBody] string name)
        {   
            await _employeeRepository.AddEmployee(name);
        }
    }
}
