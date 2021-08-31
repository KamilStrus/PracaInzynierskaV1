using Microsoft.EntityFrameworkCore.Storage;
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
      
        [Column(TypeName = "nvarchar(50)")]
        public String Kolor { get; set; }



        public long RodzajUbranieId { get; set; }
        public RodzajUbranie RodzajUbranie { get; set; }

        public long MarkaUbranieId { get; set; }
        public MarkaUbranie MarkaUbranie { get; set; }

    }
}
