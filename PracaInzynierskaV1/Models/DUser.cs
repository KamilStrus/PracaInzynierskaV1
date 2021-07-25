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


        [Column(TypeName = "nvarchar(MAX)")]
        public String name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String surname { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String phone { get; set; }

        [Column(TypeName = "image"), NotMapped]
        public byte[] image { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public String imageB { get; set; }

        //zguba
        [Column ("Zguby")]
        public ICollection<DZguba> DZguba { get; set; }
    }
}
