using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Article
{
    public class ArticleView
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }

        public string Status { get; set; }
        public string Availability { get; set; }
        public string Password { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public bool CommentStatus { get; set; }

    }
}
