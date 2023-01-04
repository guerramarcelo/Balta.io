using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Models
{
    [Table ("Tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Name", TypeName = "VARCHAR")]
        public string Name { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName ="VARCHAR")]
        public string Slug { get; set; }
    }
}
