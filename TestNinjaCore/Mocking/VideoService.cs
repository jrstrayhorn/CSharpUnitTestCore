using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace TestNinjaCore.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        // default constructor for production
        // can use for testing
        // this is poor man D.I. so use a D.I. framework!!!
        // **Ninject, StructureMap, **Autofac, Springg.Net, Unity - **recommended
        // DI Framework sets up a container with Interface/Implementation
        // will create object graph based on registry in container
        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            _fileReader = fileReader ?? new FileReader();   // file reader not null use to set
            _videoRepository = videoRepository ?? new VideoRepository();
        }

        // DI via Method Parameters, can now choose implementation to use
        public string ReadVideoTitle()
        {
            // fileReader only used here
            // so we could pass as a parameter to this method
            // string ReadVideoTitle(IFileReader)
            // that way we won't end up with bulky constructor
            // but depends on the DI framework you're using in terms
            // of how it resolves dependency method vs constructor or both
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _videoRepository.GetUnprocessedVideos();
            
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}