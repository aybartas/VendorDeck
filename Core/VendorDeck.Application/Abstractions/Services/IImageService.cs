using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Abstractions.Services
{
    public interface IImageService
    {
        Task<UploadImageDto> UploadImage(IFormFile file);

        Task<bool> DeleteImage(string publicId);


    }
}
