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
            //context.Users.Add(new User
            //{
            //    Bio = "9x Microsoft MVP",
            //    Email ="andre@balta.io2",
            //    Image = "https://balta.io",
            //    Name = "André Baltieri",
            //    PasswordHash = "1234",
            //    Slug = "andre-baltieri2"
            //});
            //context.SaveChanges();
            var user = context.Users.FirstOrDefault();

            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category= new Category
                {
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate= DateTime.Now,
                Slug ="meu-artigo",
                Summary ="Neste artigo vamos conferir...",
                Title = "Meu artigo"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }   
    }
}
