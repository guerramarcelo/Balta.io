using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    public class Profile
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
