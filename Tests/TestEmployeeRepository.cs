using Xunit;

namespace Tests
{
    public class TestEmployeeRepository
    {
        [Fact]
        public async Task TestAddRemove()
        {
            var testHelper = new TestHelper();
            var employeeRepository = testHelper.EmployeeRepository;

            employeeRepository.AddEmployee("Danya").Wait();
            Assert.True(employeeRepository.GetEmploeyersListAsync().Result.Count == 1);

            string id = await employeeRepository.GetIdByName("Danya");
            await employeeRepository.DeleteEmployee(id);

            Assert.True((await employeeRepository.GetEmploeyersListAsync()).Count == 0);
        }
    }
}
