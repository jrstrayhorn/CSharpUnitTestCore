using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        // DI via Method Parameters, can now choose implementation to use
        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
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