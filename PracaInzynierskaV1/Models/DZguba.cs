using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    public class DZguba
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String location { get; set; }

        [Column(TypeName = "image"), NotMapped]
        public byte[] image { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public String imageB { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public String freward { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String status { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


        //user
        public String user { get; set; }
        //private string userID;
        [ForeignKey("user")]
        public DUser DUser { get; set; }


    }
}
