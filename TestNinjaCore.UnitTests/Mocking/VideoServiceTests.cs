using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // should only use Mock for EXTERNAL DEPENDENCIES!!!
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideos_NoVideos_ReturnEmptyString()
        { 
            var videos = new List<Video>();
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideos_OneVideo_ReturnStringWithoutComma()
        { 
            var videos = new List<Video>();
            videos.Add(new Video { Id = 1}); 
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo("1"));
        }

        [Test]
        public void GetUnprocessedVideos_WithVideos_ReturnCommaSeparatedString()
        {
            var videos = new List<Video>();
            videos.Add(new Video { Id = 1}); 
            videos.Add(new Video { Id = 2}); 
            videos.Add(new Video { Id = 3}); 
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(videos);

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo("1,2,3"));
        }
    }
}