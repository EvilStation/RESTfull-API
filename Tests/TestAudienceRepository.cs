using RESTfull.Domain.DTO;
using Xunit;

namespace Tests
{
    public class TestAudienceRepository
    {
        [Fact]
        public void TestAddRemove()
        {
            var testHelper = new TestHelper();
            var audienceRepository = testHelper.AudienceRepository;

            AudienceDTO audienceDTO = new AudienceDTO()
            {
                AudienceNumber = 1,
                EmployeeId = null,
                AudienceType = "a",
                WorkplaceNum = 30
            };

            audienceRepository.AddAudience(audienceDTO).Wait();
            Assert.True(audienceRepository.GetAudienceListAsync().Result.Count == 1);

            audienceRepository.DeleteAudience(1).Wait();
            Assert.True(audienceRepository.GetAudienceListAsync().Result.Count == 0);
        }
        [Fact]
        public async Task TestChange()
        {
            var testHelper = new TestHelper();
            var audienceRepository = testHelper.AudienceRepository;
            var employeeRepository = testHelper.EmployeeRepository;

            employeeRepository.AddEmployee("Matthew").Wait();
            string id = await employeeRepository.GetIdByName("Matthew");

            AudienceDTO audienceDTO = new AudienceDTO()
            {
                AudienceNumber = 1,
                EmployeeId = null,
                AudienceType = "a",
                WorkplaceNum = 30
            };

            audienceRepository.AddAudience(audienceDTO).Wait();
            audienceRepository.ChangeEmployeeId(1, id).Wait();
            Assert.True(await audienceRepository.GetIdByNumber(1) != null);
        }
    }
}
