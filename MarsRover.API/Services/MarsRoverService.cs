using MarsRover.API.Config;
using MarsRover.API.Models;
using MarsRover.API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace MarsRover.API.Services
{
    public class MarsRoverService : IMarsRoverService
    {
        private readonly HttpClient _httpClient;
        private readonly MarsApiOptions _apiConfig;
        public MarsRoverService(HttpClient httpClient, IOptions<MarsApiOptions> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
        }

        public async Task<List<Image>> GetImagesByCamera(string cameraName)
        {
            List<Image> returnImagesList = new List<Image>();

            for(int i = 0; i < 10; i++)
            {
                int day = i * -1;

                Image image = new Image();
                List<ImageUrl> imageUrls = new List<ImageUrl>();

                DateTime currentDate = DateTime.Now;
                currentDate = currentDate.AddDays(day);
                string date = currentDate.ToString("yyyy-MM-dd");

                var endpoint = _apiConfig.Endpoint + "/curiosity/photos?earth_date=" + date + "&camera=" + cameraName + "&api_key=DEMO_KEY";
                var objResponse = await _httpClient.GetAsync(endpoint);

                if(objResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MarsRoverModel model = await objResponse.Content.ReadFromJsonAsync<MarsRoverModel>();

                    if(model.photos.Count > 0)
                    {
                        int index = 0;

                        foreach(var photo in model.photos)
                        {
                            if(index == 0)
                            {
                                image.Date = date;
                                ImageUrl url = new ImageUrl();
                                url.Url = photo.img_Src;
                                imageUrls.Add(url);
                            }
                            else if (index > 2)
                            {
                                break;
                            }
                            else
                            {
                                ImageUrl url = new ImageUrl();
                                url.Url = photo.img_Src;
                                imageUrls.Add(url);
                            }
                            index++;
                        }

                        image.ImageUrl = imageUrls;
                    }
                    else
                    {
                        image.Date = date;
                        image.ImageUrl = imageUrls;
                    }

                    returnImagesList.Add(image);
                }

            }

            return returnImagesList;

        }
    }
}
