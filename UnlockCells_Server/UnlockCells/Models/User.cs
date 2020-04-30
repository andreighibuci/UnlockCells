using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnlockCells.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(10)")]
        [DisplayName("RFID Code")]
        public string RFIDCode { get; set; }
        [Column(TypeName = "varchar(1)")]
        public int Access { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Department")]
        public string Department { get; set; }
    }
}
