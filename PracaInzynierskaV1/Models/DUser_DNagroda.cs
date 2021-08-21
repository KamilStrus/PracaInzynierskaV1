using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    public class DUser_DNagroda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Id { get; set; }

        public String DUserID { get; set; }
        public DNagroda Nagroda { get; set; }


        public String DNagrodaID { get; set; }
        public DUser User { get; set; }
    }
}
