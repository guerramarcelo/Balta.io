using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    [Table("[User]")]
    public class User
    {
        public User()
            => Roles = new List<Role>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Role> Roles { get; set; }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Id.ToString());
            stringBuilder.AppendLine(Name);
            stringBuilder.AppendLine(Email);
            stringBuilder.AppendLine(PasswordHash);
            stringBuilder.AppendLine(Bio);
            stringBuilder.AppendLine(Image);
            stringBuilder.AppendLine(Slug);

            foreach (var role in Roles)
            {
                stringBuilder.AppendLine(role.Id.ToString());
                stringBuilder.AppendLine(role.Name);
                stringBuilder.AppendLine(role.Slug);
            }

            return stringBuilder.ToString();
        }
    }
}
