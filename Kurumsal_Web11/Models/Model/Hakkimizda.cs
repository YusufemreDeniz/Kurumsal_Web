﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal_Web11.Models.Model
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {

        [Key] public int HakkimizdaId { get; set; }
        [Required]
        [DisplayName("Hakkımızda Açıklama")]
        public int Aciklama { get; set; }

    }
}