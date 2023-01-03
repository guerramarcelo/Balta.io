using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoriesScreen
    {
        public static void Load()
        {
            Console.WriteLine("Listar categorias");
            Console.WriteLine("---------------------");
            List();
            MenuCategoryScreen.Load();
        }
        public static void List()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.Get();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} -{category.Name} - ({category.Slug})");
            }
        }
    }
}
