using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar categoria");
            Console.WriteLine("------------------");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();
            Create(new Category
            {
                Name = nome,
                Slug = slug
            });
            MenuCategoryScreen.Load();
        }
        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Categoria cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar a categoria!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
