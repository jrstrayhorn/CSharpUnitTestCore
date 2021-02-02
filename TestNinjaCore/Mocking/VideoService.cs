using Newtonsoft.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;

        // default constructor for production
        // can use for testing
        public VideoService(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();   // file reader not null use to set
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