using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // ways to check type
            // use this one most of the time
            // NotFound - check exactly for this type
            Assert.That(result, Is.TypeOf<NotFound>());

            // result can be notFound or one of its derivatives
            // NotFound or one of its 
            // Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {}
    }
}