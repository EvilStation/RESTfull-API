using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain.DTO;
using RESTfull.Infrastructure.Data;
using RESTfull.Infrastructure.Repository;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly AudienceRepository _audienceRepository;
        public AudienceController(Context context)
        {
            _audienceRepository = new AudienceRepository(context);
        }
        // GET: api/Audience
        [HttpGet]
        public async Task<List<AudienceDTO>> Get()
        {
            return await _audienceRepository.GetAudienceListAsync();
        }
        // POST api/Audience
        [HttpPost]
        public async Task Post([FromBody] AudienceDTO audienceInfo)
        {
            await _audienceRepository.AddAudience(audienceInfo);
        }
        // PUT api/Audience/205
        [HttpPut("{number}")]
        public async Task Put(int number, [FromBody] string EmployeeId)
        {
            await _audienceRepository.ChangeEmployeeId(number, EmployeeId);
        }
        // DELETE api/Audience/205
        [HttpDelete("{number}")]
        public async Task Delete(int number)
        {
            await _audienceRepository.DeleteAudience(number);
        }
    }
}
