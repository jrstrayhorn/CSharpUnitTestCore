using System.IO;

namespace TestNinjaCore.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
    }

    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path); // we should move this to a separate class
        }
    }
}