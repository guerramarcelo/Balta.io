using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();       
        }
        static void Soma()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Segundo valor: ");
            float v2 = float.Parse(Console.ReadLine());
            Console.WriteLine($"Resultado da soma: {v1 + v2}");
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Segundo valor: ");
            float v2 = float.Parse(Console.ReadLine());
            Console.WriteLine($"Resultado da subtracao: {v1 - v2}");
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Segundo valor: ");
            float v2 = float.Parse(Console.ReadLine());
            Console.WriteLine($"Resultado da divisao: {v1 / v2}");
            Console.ReadKey();
            Menu();
        }
        
        static void Multiplicacao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Segundo valor: ");
            float v2 = float.Parse(Console.ReadLine());
            Console.WriteLine($"Resultado da multiplicacao: {v1 * v2}");
            Console.ReadKey();
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1- Soma");
            Console.WriteLine("2- Subtracao");
            Console.WriteLine("3- Divisao");
            Console.WriteLine("4- Multiplicacao");
            Console.WriteLine("5- Sair");
            Console.WriteLine("--------------");
            Console.WriteLine("Selecione uma opcao: ");
            short res = short.Parse(Console.ReadLine());
            switch (res)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multiplicacao(); break;
                case 5: Environment.Exit (0); break;
                default: Menu(); break;
            }
            Menu();
        }
    }    
}
