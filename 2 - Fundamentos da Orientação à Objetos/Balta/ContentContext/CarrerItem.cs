using Balta.NotificationContext;
using Balta.SharedContext;
using System;

namespace Balta.SharedContext
{
    public class CarrerItem : Base
    {      
        public CarrerItem(int ordem, string title, string description, Course course)
        {
            if (course == null)
                AddNotification(new Notification("Course", "Curso inválido!"));
            Order = ordem;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}
