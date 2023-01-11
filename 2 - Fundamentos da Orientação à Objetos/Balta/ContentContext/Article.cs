using Balta.NotificationContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.SharedContext
{
    public class Article : Content
    {
        public IList<Notification> Notifications { get; set; }
      
        public Article(string title, string url) : base (title, url) 
        {
        }
        

        
    }
}
