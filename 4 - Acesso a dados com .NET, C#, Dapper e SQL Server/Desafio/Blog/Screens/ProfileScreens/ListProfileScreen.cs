using Blog.Models;
using Blog.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Blog.Screens.ProfileScreens
{
    public static class ListProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar perfis");
            Console.WriteLine("---------------");
            List();
            MenuProfileScreen.Load();
        }

        public static void List()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User] 
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id] 
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = Database.Connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;

                }, splitOn: "Id");

            foreach (var user in items)
            {
                Console.WriteLine($"{user.Id} - {user.Name}");
                foreach (var role in user.Roles)
                {
                    Console.WriteLine($"{role.Id} - {role.Name} - ({role.Slug})");
                }
            }
        }
    }
}
