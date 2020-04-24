using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Db.Media
{
    public class MediaTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MediaModel> Medias { get; set; }
    }
}
