using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge.Sabra
{
    public static class ImagesService
    {
        public static ImageDto[] GetImages(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));
            if (!Regex.IsMatch(url, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$")) throw new ArgumentNullException(nameof(url));

            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var imagesDto = JsonConvert.DeserializeObject<ImageDto[]>(response.Content);
                return imagesDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static string SaveImages(ImageDto[] imagesDto)
        {
            if (imagesDto == null || !imagesDto.Any()) throw new ArgumentNullException(nameof(imagesDto));
            try
            {
                Parallel.For(0, imagesDto.Length -1, i =>
                 {
                     using (WebClient webClient = new WebClient())
                     {
                         webClient.DownloadFile(imagesDto[i].Src, imagesDto[i].Name);
                     }
                 });

                 return "Las imágenes se guardaron correctamente.";
            }
            catch (System.Exception)
            {
                return "Ocurrio un problema. No se guardo ninguna imágen.";
            }
        }
    }
}
