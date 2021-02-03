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
            // if you have too many dependencies, mmight be a code smell that the class is doing too many things
            // some of those methods belong to a different class.. those extra dependencies would go away
            // or if you're trying to mock everything.. we should only mock external dependencies
            // or if class has really complex logic so need to bring out into more dependencies
            // to make testing easier
            // if dependency is only used for one method, its better to pass that
            // dependency as a parameter to that method
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
            _videoRepository
                .Setup(vr => vr.GetUnprocessedVideos())
                .Returns(new List<Video>());

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideos_OneVideo_ReturnStringWithoutComma()
        { 
            _videoRepository
                .Setup(vr => vr.GetUnprocessedVideos())
                .Returns(new List<Video> 
                    {
                        new Video { Id = 1}
                    });

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo("1"));
        }

        [Test]
        public void GetUnprocessedVideos_WithVideos_ReturnCommaSeparatedString()
        {
            _videoRepository
                .Setup(vr => vr.GetUnprocessedVideos())
                .Returns(new List<Video> 
                    {
                        new Video { Id = 1},
                        new Video { Id = 2},
                        new Video { Id = 3}
                    });

            var csv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(csv, Is.EqualTo("1,2,3"));
        }
    }
}