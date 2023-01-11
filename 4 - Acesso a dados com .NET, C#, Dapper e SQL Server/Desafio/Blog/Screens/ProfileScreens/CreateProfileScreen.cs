using Blog.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Blog.Screens.ProfileScreens
{
    public static class CreateProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar perfil");
            Console.WriteLine("----------------");
            Console.WriteLine("UserId: ");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("RoleId: ");
            var roleId = int.Parse(Console.ReadLine());
            Create(id, roleId);
            MenuProfileScreen.Load();
        }

        public static void Create(int id, int roleId)
        {
            var sql = "spCreateUserRole";
            var parameters = new
            {
                @UserId = id,
                @RoleId = roleId,
            };
            var items = Database.Connection.Execute(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

