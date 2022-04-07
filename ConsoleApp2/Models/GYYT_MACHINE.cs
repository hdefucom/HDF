using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("GYYT_MACHINE")]
    public partial class GYYT_MACHINE
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_ID { get; set; }
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
        public string MACHINE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_TYPE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_IP { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string COMPUTER_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MAC_ADDRESS { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MACHINE_PLACE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string STATUS_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string STATUS_NAME { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? STATUS_TIME { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? IS_ENABLE { get; set; }
    }
}
