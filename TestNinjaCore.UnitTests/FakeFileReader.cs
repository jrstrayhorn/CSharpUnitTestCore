using TestNinjaCore.Mocking;

// in unit testing project not in production code
namespace TestNinjaCore.UnitTests
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";  // fake implementation to use in unit tests
        }
    }
}