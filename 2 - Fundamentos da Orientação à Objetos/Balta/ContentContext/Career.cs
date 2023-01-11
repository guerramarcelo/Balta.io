using Balta.NotificationContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.SharedContext
{
    public class Career : Content
    {
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CarrerItem>();
        }
        public IList<CarrerItem> Items { get; set; }
        public int TotalCourses => Items.Count;
       
    }
}
