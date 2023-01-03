using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar usuários");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.Get();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name}");
            }
        }
    }
}
