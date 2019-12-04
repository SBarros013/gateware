using System;
using Enums;
using Services;
using Xunit;
using FluentAssertions;
using System.IO;

namespace test
{
    public class DirectoryServiceUnitTest
    {
        [Fact]
        public void CreateNewDirectory_GivenInexistentDirectory_ReturnStatusSuccess()
        {
            //arrange
            DirectoryService service = new DirectoryService("");
            string directoryName = "firstDirectory";

            //act
            DirectoryStatus d = service.CreateNewDirectory(directoryName);

            //assert
            d.Should().Be(DirectoryStatus.Success);

            Directory.Delete(directoryName);
        }

        [Fact]
        public void CreateNewDirectory_GivenExistentDirectory_ReturnStatusAlreadyExistent()
        {
            //arrange
            DirectoryService service = new DirectoryService("");
            string directoryName = "firstDirectory";
            Directory.CreateDirectory(directoryName);

            //act
            DirectoryStatus d = service.CreateNewDirectory(directoryName);

            //assert
            d.Should().Be(DirectoryStatus.AlreadyExists);

            Directory.Delete(directoryName);
        }

        [Fact]
        public void CreateNewDirectory_GivenInvalidPath_ReturnStatusFailed()
        {
            //arrange
            DirectoryService service = new DirectoryService("///");
            string directoryName = "firstDirectory";

            //act
            DirectoryStatus d = service.CreateNewDirectory(directoryName);

            //assert
            d.Should().Be(DirectoryStatus.Failed);
        }

        [Fact]
        public void CopyImages_GivenInvalidFromPath_ReturnStatusInexistent()
        {
            //arrange
            DirectoryService service = new DirectoryService("");
            string fromDirectory = "fromDirectory";
            string toDirectory = "toDirectory";

            //act
            DirectoryStatus d = service.CopyImages(fromDirectory, toDirectory);

            //assert
            d.Should().Be(DirectoryStatus.Inexistent);
        }

        [Fact]
        public void CopyImages_GivenInvalidToPath_ReturnStatusInexistent()
        {
            //arrange
            DirectoryService service = new DirectoryService("");
            string fromDirectory = "fromDirectory";
            string toDirectory = "toDirectory";
            Directory.CreateDirectory(fromDirectory);

            //act
            DirectoryStatus d = service.CopyImages(fromDirectory, toDirectory);

            //assert
            d.Should().Be(DirectoryStatus.Inexistent);
            
            Directory.Delete(fromDirectory);
        }

        [Fact]
        public void CopyImages_GivenValidsPaths_ReturnStatusSuccess()
        {
            //arrange
            DirectoryService service = new DirectoryService("");
            string fromDirectory = "fromDirectory";
            string toDirectory = "toDirectory";
            Directory.CreateDirectory(fromDirectory);
            Directory.CreateDirectory(toDirectory);
            string imgName = "img.jpg";
            string img = Path.Combine(fromDirectory, imgName);
            using (FileStream fs = File.Create(img))
            {
                for (byte i = 0; i < 10; i++)
                    fs.WriteByte(i);
            }

            //act
            DirectoryStatus d = service.CopyImages(fromDirectory, toDirectory);

            //assert
            d.Should().Be(DirectoryStatus.Success);
            
            Directory.Delete(fromDirectory, true);
            Directory.Delete(toDirectory, true);
        }
    }
}
