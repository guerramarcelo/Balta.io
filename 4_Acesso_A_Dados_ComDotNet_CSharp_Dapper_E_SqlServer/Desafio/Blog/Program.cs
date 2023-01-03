using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.ProfileScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog
{
    public class Program
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();
            Load();
            Console.ReadKey();
            Database.Connection.Close();
        }

        //---------- DESAFIO
        private static void Load()
        {
            Console.WriteLine("Meu Blog");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Gestão de usuário");
            Console.WriteLine("2- Gestão de perfil");
            Console.WriteLine("3- Gestão de categoria");
            Console.WriteLine("4- Gestão de tag");
            Console.WriteLine("5- Vincular perfil/usuário");
            Console.WriteLine("6- Vincular post/tag");
            Console.WriteLine();
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;

                case 2:
                    MenuProfileScreen.Load();
                    break;

                case 3:
                    MenuCategoryScreen.Load();
                    break;

                case 4:
                    MenuTagScreen.Load();
                    break;

                case 5:
                    GetProfile(Database.Connection);
                    break;

                case 6:
                    GetPostTag(Database.Connection);
                    break;

                default: Load(); break;
            }
        }

        public static void GetProfile(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            repository.GetWithRoleById();
        }
        public static List<Post> GetPostTag(SqlConnection connection)
        {
            var query = @"
                SELECT 
                    [Post].*,
                    [Tag].*
                FROM
                    [User] 
                LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id] 
                LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]"
            ;
            var posts = new List<Post>();

            var items = connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pos = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pos == null)
                    {
                        pos = post;
                        if (tag != null)
                            pos.Tags.Add(tag);

                        posts.Add(pos);
                    }
                    else
                        pos.Tags.Add(tag);
                    return post;

                }, splitOn: "Id");
            return posts;
        }
    }
}
