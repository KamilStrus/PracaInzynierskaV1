﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    [Table("DZgubaUbranie")]
    public class DZguba_Ubranie : DZguba

    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Rodzaj { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Marka { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Kolor { get; set; }

    }
}