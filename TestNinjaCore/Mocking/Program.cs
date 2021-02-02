namespace TestNinjaCore.Mocking
{
    public class Program
    {
        public static void Main()
        {
            // in real world we don't manually new this up
            // we use DI framework that doesn't this for us!
            // would need DI framework like Ninject or Autfac to get this to work
            // via container to register dependencies
            var service = new VideoService();
            var title = service.ReadVideoTitle();
        }
    }
}