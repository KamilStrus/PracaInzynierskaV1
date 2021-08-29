using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaInzynierskaV1.Models
{
    public class DNagroda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String name { get; set; }

        [Column(TypeName = "image"), NotMapped]
        public byte[] image { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public String imageB { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String description { get; set; }

        [Column(TypeName = "int")]
        public Int32 cost { get; set; }

        [Column(TypeName = "int")]
        public Int32 ilosc { get; set; }

        //Uzytkownicy
        [Column("Users")]
        public ICollection<DUser_DNagroda> DUser_DNagroda { get; set; }

    }
}
