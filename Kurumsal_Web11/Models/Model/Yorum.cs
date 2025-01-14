using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Kurumsal_Web11.Models.Model;

namespace Kurumsal_Web11.Models
{
    [Table("Yorum")]
    public class Yorum
    {
        public int YorumId { get; set; }
        [Required,StringLength(50,ErrorMessage ="50 Karakter Olabilir!!")]
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        [DisplayName("Yorumunuz:")]
        public string YorumIcerik { get; set; }
        public bool Onay { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}