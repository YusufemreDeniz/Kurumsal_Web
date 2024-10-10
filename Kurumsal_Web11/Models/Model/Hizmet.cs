using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal_Web11.Models.Model
{
    [Table("Hizmet")]
    public class Hizmet
    {
        [Key]
        public int HizmetID { get; set; }
        [Required, StringLength(150,ErrorMessage ="150 Karakter Olmalıdır!!")]
        [DisplayName("Hizmet Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet Resim")]
        public string ResimURL { get; set; }
    }
}