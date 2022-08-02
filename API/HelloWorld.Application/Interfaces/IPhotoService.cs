using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}