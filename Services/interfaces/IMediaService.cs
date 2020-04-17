using CMS.Models.Db.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IMediaService
    {
        Task<bool> Create(MediaModel media);
        Task<MediaModel> Get(int id);
        Task<List<MediaModel>> GetAll();
        Task<bool> Update(MediaModel media);
        Task<bool> Delete(int id);
    }
}
