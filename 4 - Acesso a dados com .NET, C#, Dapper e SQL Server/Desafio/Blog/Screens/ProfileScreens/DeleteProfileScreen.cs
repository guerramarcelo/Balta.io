using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.ProfileScreens
{
    public static class DeleteProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar perfil");
            Console.WriteLine("-----------------");
            Console.WriteLine("Qual o id do usuário que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o id da role do usuário que deseja excluir: ");
            var roleId = int.Parse(Console.ReadLine());
            MenuProfileScreen.Load();
        }

        public static void Delete(int id, int roleId)
        {
            var userRepository = new Repository<User>(Database.Connection);
            userRepository.Delete(id);

        }
    }
}
