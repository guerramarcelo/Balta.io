using Blog.Data;
using Blog.Models;
using System;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }
    }
}
