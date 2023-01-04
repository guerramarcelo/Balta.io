﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(160)]
        [Column("Title", TypeName = "VARCHAR")]
        public string Title { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        [Column("Sumary", TypeName = "VARCHAR")]
        public string Summary { get; set; }


        [Required]        
        [Column("Body", TypeName = "TEXT")]
        public string Body { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }

        [Required]
        [Column("CreateDate", TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("LastUpdateDate", TypeName = "DATETIME")]
        public DateTime LastUpdateDate { get; set; }
    }
}
