﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    [Table("Tag")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        
        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}
