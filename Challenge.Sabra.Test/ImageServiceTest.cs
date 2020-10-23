using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace Challenge.Sabra.Test
{
    [TestFixture]
    public class ImageServiceTest
    {
        [TestCase("")]
        [TestCase("asd")]
        public void TestGetImagesWithInvalidUrl(string url)
        {
            Assert.Throws<ArgumentNullException>(() => ImagesService.GetImages(url));
        }

        [TestCase(@"https://gruposabra.github.io/test/images.json")]
        public void TestGetImagesWithValidUrl(string url)
        {
            var imagesDto = ImagesService.GetImages(url);
            Assert.IsNotNull(imagesDto);
            Assert.IsTrue(imagesDto is ImageDto[]);
            Assert.IsTrue(imagesDto.Length > 0);
        }

        [TestCase]
        public void TestSaveImagesWithInvaledDto()
        {
            Assert.Throws<ArgumentNullException>(() => ImagesService.SaveImages(null));
            Assert.Throws<ArgumentNullException>(() => ImagesService.SaveImages(new ImageDto[] { }));
        }

        [TestCase]
        public void TestSaveCorrectly()
        {
            var imagesDto = ImagesService.GetImages(@"https://gruposabra.github.io/test/images.json");
            var saveMessage = ImagesService.SaveImages(imagesDto);
            Assert.IsNotNull(saveMessage);
            Assert.That(saveMessage, Is.EqualTo("Las imágenes se guardaron correctamente."));
        }
    }
}
