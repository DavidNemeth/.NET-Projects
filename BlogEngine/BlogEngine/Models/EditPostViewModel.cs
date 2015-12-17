using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }        
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; } 
        public IList<Category> Category { get; set; }
        public IList<Tag> Tags { get; set; }
        public Post Post { get; set; }
    }
}