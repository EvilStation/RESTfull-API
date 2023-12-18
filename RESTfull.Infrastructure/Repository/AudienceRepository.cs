using Microsoft.EntityFrameworkCore;
using RESTfull.Domain.DTO;
using RESTfull.Domain.Model;
using RESTfull.Infrastructure.Data;

namespace RESTfull.Infrastructure.Repository
{
    public class AudienceRepository
    {
        private readonly Context _context;
        public AudienceRepository(Context context) => _context = context;
        public async Task<List<AudienceDTO>> GetAudienceListAsync()
        {
            List<Audience> audiences = await _context.Audiences.ToListAsync();

            List<AudienceDTO> dto = new();
            foreach (var audience in audiences)
            {
                dto.Add(new AudienceDTO()
                {
                    EmployeeId = audience.EmployeeId,
                    AudienceNumber = audience.AudienceNumber,
                    AudienceType = audience.AudienceType,
                    WorkplaceNum = audience.WorkplaceNum

                });
            }
            return dto.ToList();
        }
        public async Task AddAudience(AudienceDTO audienceInfo)
        {
            Employee e = await _context.Employees.FirstOrDefaultAsync(e => e.Id.Equals(audienceInfo.EmployeeId));
            Audience a = await _context.Audiences.FirstOrDefaultAsync(e => e.AudienceNumber == audienceInfo.AudienceNumber);
            if ((e != null || audienceInfo.EmployeeId == null) && a == null)
            {
                Audience audience = new();
                audience.AudienceNumber = audienceInfo.AudienceNumber;
                audience.EmployeeId = audienceInfo.EmployeeId;
                audience.AudienceType = audienceInfo.AudienceType;
                audience.WorkplaceNum = audienceInfo.WorkplaceNum;
                _context.Audiences.Add(audience);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ChangeEmployeeId(int number, string EmployeeId)
        {
            Audience audience = await _context.Audiences.FirstOrDefaultAsync(e => e.AudienceNumber == number);
            if (audience != null)
            {
                audience.EmployeeId = new Guid(EmployeeId);
                _context.Audiences.Update(audience);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAudience(int number)
        {
            Audience audience = await _context.Audiences.FirstOrDefaultAsync(e => e.AudienceNumber == number);
            if (audience != null)
            {
                _context.Audiences.Remove(audience);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string> GetIdByNumber(int number) // для тестов
        {
            Audience audience = await _context.Audiences
                .Where(e => e.AudienceNumber == number)
                .FirstOrDefaultAsync();
            return audience.Id.ToString();
        }
    }
}
