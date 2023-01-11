using Blog.Data;
using System;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                var user = context.Users;
                foreach (var item in user)
                {
                    Console.WriteLine(item);
                }
            }
            
            
        }   
    }
}
