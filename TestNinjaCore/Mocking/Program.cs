namespace TestNinjaCore.Mocking
{
    public class Program
    {
        public static void Main()
        {
            // in real world we don't manually new this up
            // we use DI framework that doesn't this for us!
            var service = new VideoService();
            var title = service.ReadVideoTitle();
        }
    }
}