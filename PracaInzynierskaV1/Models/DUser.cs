using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    public class DUser
    {

       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String id { get; set; }

        //zguba
        public ICollection<DZguba> DZguba { get; set; }
    }
}
