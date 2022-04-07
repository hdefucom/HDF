using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("GYYT_STATUS_RECORD")]
    public partial class GYYT_STATUS_RECORD
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string STATUS_RECORD_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string CREATOR { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? CREATE_TIME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string STATUS_RECORD_TYPE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_TYPE_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_TYPE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string STATUS_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MEMO { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? STATUS_TIME { get; set; }
    }
}
