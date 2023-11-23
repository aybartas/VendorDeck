using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _config;
        private readonly Cloudinary _cloudinary;
        public ImageService(IConfiguration config, Cloudinary cloudinary)
        {
            _config = config;
            _cloudinary = cloudinary;
        }

        public async Task<UploadImageDto> UploadImage(IFormFile file)
        {
            var uploadResult = new UploadImageDto {};

            if(file.Length <= 0)
            {
                uploadResult.Error = "File is empty";
                uploadResult.IsSuccess = false;
                return uploadResult;
            }

            using var stream =  file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
            };

            var cloudinaryResult  = await _cloudinary.UploadAsync(uploadParams);

            uploadResult.Url = cloudinaryResult.SecureUrl;
            uploadResult.IsSuccess = cloudinaryResult.StatusCode == System.Net.HttpStatusCode.Created;
            uploadResult.PublicId = cloudinaryResult.PublicId;

            return uploadResult;
        }

        public async Task<bool> DeleteImage(string publicId)
        {
            var deleteResult = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteResult);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
