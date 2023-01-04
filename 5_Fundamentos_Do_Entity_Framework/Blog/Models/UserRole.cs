using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Models
{
    [Table("UserRole")]
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
