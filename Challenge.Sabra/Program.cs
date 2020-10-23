namespace Challenge.Sabra
{
    class Program
    {
        static void Main(string[] args)
        {
            var imagesDto = ImagesService.GetImages(@"https://gruposabra.github.io/test/images.json");
            var saveMessage = ImagesService.SaveImages(imagesDto);
            System.Console.WriteLine(saveMessage);
        }
    }
}
