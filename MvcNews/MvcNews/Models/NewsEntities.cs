﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcNews.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public ICollection<NewsTag> NewsTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
    public class NewsTag
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }
        public ICollection<News> News { get; set; }        
    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<News> News { get; set; }
    }
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        [Required]
        public string Text { get; set; }
        public News News { get; set; }
        public int NewsID { get; set; }
    }

}