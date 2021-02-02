using System.IO;
using System.Text.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        public string ReadVideoTitle()
        {
            // tightly coupled to FileReader - need to use interface
            var str = new FileReader().Read("video.txt");
            var video = JsonSerializer.Deserialize<Video>(str);
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