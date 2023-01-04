using Blog.Data;
using Blog.Models;
using System;
using System.Linq;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            var user = new User
            {
                Name = "Marcelo Guerra",
                Slug = "marceloguerra",
                Email = "marcelo@balta.io",
                Bio = "Estudante",
                Image = "https://balta.io",
                PasswordHash = "24012998"
            };

            var category = new Category
            {
                Name = "Backend",
                Slug = "backend"
            };

            var post = new Post
            {
                Author = user,
                Category = category,
                Body = "<p>Hello World</p>",
                Slug = "comecando-com-ef-core",
                Summary = "Neste artigo estou aprendendo EF Core",
                Title = "Começando com EF Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
