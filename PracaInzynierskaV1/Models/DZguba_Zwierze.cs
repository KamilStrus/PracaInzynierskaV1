using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    [Table("DZgubaZwierze")]
    public class DZguba_Zwierze : DZguba
        
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String gatunek { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String umaszczenie { get; set; }

    }
}
