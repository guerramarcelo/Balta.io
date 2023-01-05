using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();
            var post = context
                .Posts
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderBy(x => x.LastUpdateDate)
                .FirstOrDefault();
            post.Author.Name = "Teste";
            context.Posts.Update(post);
            context.SaveChanges();
        }   
    }
}
