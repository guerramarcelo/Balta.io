using Blog.Screens.TagScreens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.ProfileScreens
{
    public static class MenuProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Perfis");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Listar os perfis");
            Console.WriteLine("2- Cadastrar perfil");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ListTagsScreen.Load();
                    break;

                case 2:
                    CreateTagScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}
