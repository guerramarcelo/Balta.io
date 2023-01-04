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
            var posts = context
                .Posts
                .AsNoTracking()   
                .Include(x => x.Author)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToList();
            
            foreach (var post in posts)
                Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
        }   
    }
}
