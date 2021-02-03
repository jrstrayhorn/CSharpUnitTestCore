using System.Net;

namespace TestNinjaCore.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string fileName);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string fileName)
        {
            var client = new WebClient();
            client.DownloadFile(url, fileName);
        }
    }
}