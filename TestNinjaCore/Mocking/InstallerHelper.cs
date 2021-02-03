using System.Net;

namespace TestNinjaCore.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        private string _setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader = null)
        {
            _fileDownloader = fileDownloader ?? new FileDownloader();
        }

        // use the correct format of url based on parameters - interaction test
        // if download worked, return true
        // if download failed, return false
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                // this class should be responsible for constructing the correct url
                // because it knows about customerName, installerName
                // it's a higher level class that knows about business domain
                // BUT it'd delegating the task to download to fileDownloader
                _fileDownloader.DownloadFile(string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);
                
                return true;
            }
            catch (WebException)
            {
                // we want to catch this specific error
                // any other exceptions we want to propagate to our logger
                return false;
            }
        }
    }
}