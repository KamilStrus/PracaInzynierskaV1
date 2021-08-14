using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    public class Email
    {
        [Key]
       
        public String id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String clientemail { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String content { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String name { get; set; }

        [Column(TypeName = "bit")]
        public bool sent { get; set; }

    }
}
