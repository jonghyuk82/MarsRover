using MarsRover.API.Models;
using MarsRover.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MarsRover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsRoverController : ControllerBase
    {
        private string imageListCacheKey;
        private readonly IMarsRoverService _marsRoverService;
        private readonly IMemoryCache _memoryCache;        

        public MarsRoverController(IMarsRoverService marsRoverService, IMemoryCache memoryCache)
        {
            _marsRoverService = marsRoverService;
            _memoryCache = memoryCache;
            imageListCacheKey = DateTime.Today.ToString("yyyy-MM-dd");
        }

        [HttpGet("{cameraName}", Name = "GetImage")]
        public async Task<IActionResult> GetImagesByCamera(string cameraName)
        {            
            List<Image> returnList = new List<Image>();

            if(_memoryCache.TryGetValue(imageListCacheKey, out List<Image> images))
            {
                return Ok(images);                
            }
            else
            {
                images = await _marsRoverService.GetImagesByCamera(cameraName);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                _memoryCache.Set(imageListCacheKey, images, cacheEntryOptions);

                if(images.Any())
                {
                    return Ok(images);
                }                
            }

            return NotFound();
        }
    }
}
