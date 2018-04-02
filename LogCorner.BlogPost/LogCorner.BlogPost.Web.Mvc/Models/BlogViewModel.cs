using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogCorner.BlogPost.Web.Mvc.Models
{
    public class BlogForCreationViewModel
    {
        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }
    }

    public class BlogForDetailViewModel
    {
        public int BlogId { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public IEnumerable<PostViewModel> PostViewModels { get; set; }
    }

    public class BlogForEditViewModel
    {
        public int BlogId { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }
    }

    public class BlogViewModel
    {
        public int BlogId { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        public string Owner { get; set; }

        public IEnumerable<PostViewModel> PostViewModels { get; set; }
    }

    public class PostViewModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public string Url { get; set; }
    }

    public class PostForCreationViewModel
    {
        public int? BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class PostForEditViewModel
    {
        public int? PostId { get; set; }
        public int? BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}