using Blog.Screens.TagScreens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.UserScreens
{
    public class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Usuários");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Listar os usuários");
            Console.WriteLine("2- Cadastrar usuário");
            Console.WriteLine("3- Atualizar um usuário");
            Console.WriteLine("4- Excluir uma usuário");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ListUserScreen.Load();
                    break;

                case 2:
                    CreateUserScreen.Load();
                    break;

                case 3:
                    UpdateUserScreen.Load();
                    break;

                case 4:
                    DeleteUserScreen.Load();
                    break;

                default: Load(); break;

            }
        }
    }
}
