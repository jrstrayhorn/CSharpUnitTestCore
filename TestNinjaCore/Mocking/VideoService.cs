using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        public IFileReader FileReader { get; set; }

        public VideoService()
        {
            FileReader = new FileReader();
        }
        
        // DI via Method Parameters, can now choose implementation to use
        public string ReadVideoTitle()
        {
            var str = FileReader.Read("video.txt");
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