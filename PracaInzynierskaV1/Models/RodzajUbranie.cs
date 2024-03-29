﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PracaInzynierskaV1.Models
{
    public class RodzajUbranie
    {

        [Key]
        public Int64 id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String rodzajubrania { get; set; }


        [Column("DZguba_Ubranie")]
        public ICollection<DZguba_Ubranie> DZguby_Ubranie { get; set; }

    }


}

