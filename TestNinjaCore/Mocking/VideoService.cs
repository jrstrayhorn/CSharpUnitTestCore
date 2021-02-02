using System.IO;
using System.Text.Json;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        public string ReadVideoTitle()
        {
            var str = File.ReadAllText("video.txt");
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