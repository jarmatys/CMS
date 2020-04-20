﻿using CMS.Models.Db.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.interfaces
{
    public interface IMediaService
    {
        Task<MediaModel> Get(string id);
        Task<List<MediaModel>> GetAll();
        Task<int> MediaCount();
    }
}
