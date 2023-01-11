using System;
using System.IO;
using System.Text;

namespace EditorHtml
{
    public class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-------------");
            Start();
        }
        public static void Start()
        {
            var file = new StringBuilder();
            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Viewer.Show(file.ToString());
            
            
            Console.WriteLine("-------------");
            Console.WriteLine(" Deseja salvar o arquivo? S/N");                        
            
            var resposta = char.Parse(Console.ReadLine().ToLower());

            if (resposta == 's')
            {
                Console.WriteLine("Insira o local que deseja salvar o arquivo");
                var path = Console.ReadLine();

                using (var arquivo = new StreamWriter(path))
                {
                    arquivo.Write(file.ToString());
                }
                Console.WriteLine($"Arquivo {path} salvo com sucesso!");
                Console.ReadLine();
                Menu.Show();
            }
            
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
