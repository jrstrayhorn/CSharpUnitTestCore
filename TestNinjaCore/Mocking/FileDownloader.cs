using System.Net;

namespace TestNinjaCore.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        // this is a lower level class so it should be dumb
        // and not know about the business domain
        // we are just encapsulating the external dependency to WebClient
        // if WebClient had an interface like IWebClient then we could
        // just inject that interface in InstallerHelper and wouldn't
        // need to create this IFileDownloader 
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}