﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal_Web11.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }
        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public ICollection<Yorum> Yorums { get; set; }
    }
}