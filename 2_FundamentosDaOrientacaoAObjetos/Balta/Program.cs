using Balta.SharedContext;
using Balta.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balta
{
    public class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "oriencacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
            var courses = new List<Course>();
            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");
            
            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var careers = new List<Career>();
            var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
            var carerItem = new CarrerItem(1,"Comece por aqui", "", courseCsharp);
            var carerItem2 = new CarrerItem(2, "Aprenda OOP", "", courseOOP);
            var carerItem3 = new CarrerItem(3, "Aprenda .NET", "", courseAspNet);
            careerDotnet.Items.Add(carerItem);
            careerDotnet.Items.Add(carerItem2);
            careerDotnet.Items.Add(carerItem3);
            careers.Add(careerDotnet);

            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach(var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }                                             
            }
            
            var payPalSubscription = new PayPalSubscription(); 
            var student = new Student();
            student.CreateSubscription(payPalSubscription);
        }
    }
}
