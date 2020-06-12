using CloudinaryDotNet.Actions;
using CMS.Areas.Admin.Models.Db.Article;
using CMS.Areas.Admin.Models.Db.Media;
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
        Task<bool> AddMultipleFiles(List<IFormFile> files);
        bool DeleteFile(string publicId);
    }
}
