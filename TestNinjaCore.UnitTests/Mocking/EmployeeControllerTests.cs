using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _employeeController = new EmployeeController(_storage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectActionResult()
        {
            var result = _employeeController.DeleteEmployee(1);
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ShouldRemoveEmployee()
        {
            _employeeController.DeleteEmployee(1);
            _storage.Verify(es => es.DeleteEmployee(1));
        }
    }
}