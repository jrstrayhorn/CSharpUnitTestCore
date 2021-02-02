using Newtonsoft.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;

        // default constructor for production
        // can use for testing
        // this is poor man D.I. so use a D.I. framework!!!
        // **Ninject, StructureMap, **Autofac, Springg.Net, Unity - **recommended
        // DI Framework sets up a container with Interface/Implementation
        // will create object graph based on registry in container
        public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader;   // file reader not null use to set
        }

        // DI via Method Parameters, can now choose implementation to use
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }
}