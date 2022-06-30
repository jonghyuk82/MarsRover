using MarsRover.API.Models;

namespace MarsRover.API.Services.Interfaces
{
    public interface IMarsRoverService
    {
        public Task<List<Image>> GetImagesByCamera(string cameraName);
    }
}
