using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogEngine.Models //TODO: reply? like? video? pic?
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class Post
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
        public string Meta { get; set; }
        [Required]
        public string UrlOpt { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; }        
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlOpt { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlOpt { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UrlOpt { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        public ICollection<Post> Posts { get; set; }
    }      
}