using CloudinaryDotNet.Actions;
using CMS.Models.Db.Article;
using CMS.Models.Db.Media;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface ICloudService
    {
        Task<MediaModel> AddFile(IFormFile file, ArticleModel article = null);
        bool AddMultipleFiles(List<IFormFile> files);
        Task<bool> DeleteFile(string publicId);
    }
}
