using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    [Table("DZgubaElektronika")]
    public class DZguba_Elektronika : DZguba

    {

        [Column(TypeName = "nvarchar(50)")]
        public String Rodzaj { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Producent { get; set; }

    }
}
