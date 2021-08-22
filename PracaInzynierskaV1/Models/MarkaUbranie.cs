using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaInzynierskaV1.Models
{
    public class MarkaUbranie
    {
        [Key]
        public String id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String markaubrania { get; set; }
    }
}
