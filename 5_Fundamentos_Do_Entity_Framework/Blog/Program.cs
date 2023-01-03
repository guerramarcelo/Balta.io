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
            using (var context = new BlogDataContext())
            {
                //Create
                //var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                //context.Tags.Add(tag);
                //context.SaveChanges();

                //Update
                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                //tag.Name = ".NET";
                //tag.Slug = "dotnet";
                //context.Update(tag);
                //context.SaveChanges();

                //Delete
                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                //context.Remove(tag);
                //context.SaveChanges();

                //Read
                var tags = context
                    .Tags
                    .Where(x => x.Name.Contains(".NET"))
                    .ToList();

                foreach (var tag in tags)
                {
                    Console.WriteLine(tag.Name);
                }
            }
        }
    }
}
