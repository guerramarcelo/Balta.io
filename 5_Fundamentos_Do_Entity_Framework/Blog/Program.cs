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
