using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    public class Program
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            //CreateUser(connection);
            //ReadUsers(connection);  
            ReadUsersWithRoles(connection);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User
            {
                Name = "Marcelo Guerra",
                Email = "mbg1998137@gmail.com",
                PasswordHash = "HASH",
                Bio = "Estudante",
                Image = "http://",
                Slug = "marcelo-guerra"
            };
            
            var repository = new Repository<User>(connection);
            repository.Create(user);            
        }
        public static void CreateRole(SqlConnection connection)
        {
            var role = new Role
            {
                Name = "User",
                Slug = "user"
            };

            var repository = new Repository<Role>(connection);
            repository.Create(role);
        }
        public static void CreateTag(SqlConnection connection)
        {
            var tag = new Tag
            {
                Name ="C#",
                Slug ="csharp"
            };
            var repository = new Repository<Tag>(connection);
            repository.Create(tag);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = new User();
            var repository = new Repository<User>(connection);
            repository.Update(user);
        }

        public static void UpdateRole(SqlConnection connection)
        {
            var role = new Role();
            var repository = new Repository<Role>(connection);
            repository.Update(role);
        }

        public static void UpdateTag(SqlConnection connection)
        {
            var tag = new Tag();
            var repository = new Repository<Tag>(connection);
            repository.Update(tag);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var user = new User();
            var repository = new Repository<User>(connection);
            repository.Delete(user);
        }
        public static void DeleteRole(SqlConnection connection)
        {
            var role = new Role();
            var repository = new Repository<Role>(connection);
            repository.Delete(role);
        }
        public static void DeleteTag(SqlConnection connection)
        {
            var tag = new Tag();
            var repository = new Repository<Tag>(connection);
            repository.Delete(tag);
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                
                foreach(var role in item.Roles)
                    Console.WriteLine($"- {role.Name}");
            }
        }
    }

}
