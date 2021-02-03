using System.Net;
using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IFileDownloader> _fileDownloader;
        
        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadSuccessful_ReturnTrue()
        {
            // no need to mock method because it doesn't return anything
            //_fileDownloader.Setup(fd => fd.DownloadFile("", ""));

            var result = _installerHelper.DownloadInstaller("test", "test");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_DownloadFailed_ReturnFalse()
        { 
            //_fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            // NOW the mock is more generic!!
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        // this test is too specific - so be careful with this one
        // if api paths change any of these types of tests will break
        [Test]
        public void DownloadInstaller_WithCustomerInstallerName_ShouldUseCorrectUrl()
        { 
            var urlToDownload = "http://example.com/testCustomer/testInstaller";
            _installerHelper.DownloadInstaller("testCustomer", "testInstaller");
            _fileDownloader.Verify(fd => fd.DownloadFile(urlToDownload, null));
        }
    }
}