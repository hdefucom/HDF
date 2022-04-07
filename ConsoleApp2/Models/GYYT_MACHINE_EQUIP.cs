using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("GYYT_MACHINE_EQUIP")]
    public partial class GYYT_MACHINE_EQUIP
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_EQUIP_ID { get; set; }
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
        public string MODIFIER { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? MODIFY_TIME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_TYPE_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_TYPE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_STATUS_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EQUIP_STATUS_NAME { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? EQUIP_STATUS_TIME { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? IS_ENABLE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MEMO { get; set; }
    }
}
