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
        public string Meta { get; set; }
        public string UrlOpt { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; }
        public ICollection<CategoryToPost> PostCategory { get; set; }
        public ICollection<TagToPost> PostTag { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryToPost> PostCategory { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TagToPost> PostTag { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
    }
    //csatolások
    public class CategoryToPost //Posthoz kategoriát
    {
        [Key]
        [Column(Order = 0)]
        public int PostId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
    public class TagToPost //Posthoz Taget
    {
        [Key]
        [Column(Order = 0)]
        public int PostId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}