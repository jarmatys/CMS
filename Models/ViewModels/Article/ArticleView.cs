using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.ViewModels.Article
{
    public class ArticleView
    {
        [Required(ErrorMessage = "Uzupełnij tytuł wpisu")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Uzupełnij adres url wpisu")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Wpis nie może być pusty")]
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public IFormFile FeaturedImg { get; set; }

        [Required(ErrorMessage = "Wpis musi mieć datę publikacji")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Wpis musi mieć godzinę publikacji")]
        public DateTime Time { get; set; }

        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public bool CommentStatus { get; set; }
        public bool IsDraft { get; set; }

    }
}
