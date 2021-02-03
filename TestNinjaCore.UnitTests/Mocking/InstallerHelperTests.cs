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
        public void DownloadInstaller_DownloadSuccessful_ShouldReturnTrue()
        {
            //_fileDownloader.Setup(fd => fd.DownloadFile("", ""));

            var result = _installerHelper.DownloadInstaller("test", "test");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_DownloadFailed_ShouldReturnFalse()
        { 
            _fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/test/test", null)).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("test", "test");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DownloadInstaller_WithCustomerInstallerName_ShouldUseCorrectUrl()
        { 
            var urlToDownload = "http://example.com/testCustomer/testInstaller";
            _installerHelper.DownloadInstaller("testCustomer", "testInstaller");
            _fileDownloader.Verify(fd => fd.DownloadFile(urlToDownload, null));
        }
    }
}