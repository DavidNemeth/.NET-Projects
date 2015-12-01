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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Meta { get; set; }
        public string UrlOpt { get; set; }
        public bool Published { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlOpt { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlOpt { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }
        public string UrlOpt { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    //csatolások    
}