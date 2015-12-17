using BlogEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.DAL
{
    public interface IBlogRepository : IDisposable
    {
        Post GetPost(int PostId);
        IList<Post> GetPosts();
        IList<Tag> GetTags(Post post);
        IList<Category> GetCategory(Post post);        
        int TotalPosts();
        void AddPost(Post psot);
        Tag GetTag(string tagname);
        Post GetPost(int? id);
    }
}
