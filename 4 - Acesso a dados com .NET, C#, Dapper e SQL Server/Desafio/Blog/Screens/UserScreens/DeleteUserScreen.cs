using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir usuário");
            Console.WriteLine("---------------");
            Console.WriteLine("Qual o id do usuário que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
