using CMS.Areas.Admin.Models.Db.Media;
using CMS.Areas.Admin.Models.View.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class MediaHelpers
    {
        public static MediaModel ConvertToModel(MediaView result)
        {
            var mediaModel = new MediaModel { };
            return mediaModel;
        }

        public static MediaView ConvertToView(MediaModel result)
        {
            var mediaView = new MediaView
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Url = result.Url
            };
            return mediaView;
        }

        public static MediaModel MergeViewWithModel(MediaModel model, MediaView view)
        {
            model.Name = view.Name;
            model.Description = view.Description;

            return model;
        }
    }
}
