using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeStorage> _employeeStorage;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
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
            _employeeStorage.Verify(es => es.Remove(1));
        }
    }
}