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
          
        [Column(TypeName = "nvarchar(50)")]
        public String umaszczenie { get; set; }

        public long GatunekId { get; set; }
        public Gatunek Gatunek { get; set; }

    }
}
