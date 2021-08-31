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


        public long ProducentsId { get; set; }
        public Producents Producents { get; set; }

        public long RodzajElektronikaId { get; set; }
        public RodzajElektronika RodzajElektronika { get; set; }

    }
}
