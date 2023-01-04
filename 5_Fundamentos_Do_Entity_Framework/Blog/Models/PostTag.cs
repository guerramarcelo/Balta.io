using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Models
{
    [Table("PostTag")]
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
