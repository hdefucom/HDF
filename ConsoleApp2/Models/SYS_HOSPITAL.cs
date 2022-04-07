using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_HOSPITAL")]
    public partial class SYS_HOSPITAL
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string HOSPITAL_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string HOSPITAL_NAME { get; set; }
        [Column(TypeName = "BLOB")]
        public byte[] HOSPITAL_ICON { get; set; }
        [Column(TypeName = "BLOB")]
        public byte[] HOSPITAL_QR_CODE { get; set; }
        [Column(TypeName = "CLOB")]
        public string HOSPITAL_INTRODUCE { get; set; }
    }
}
