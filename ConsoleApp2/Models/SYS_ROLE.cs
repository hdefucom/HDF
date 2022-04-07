using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_ROLE")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE4")]
    [Index("ROLE_NAME", Name = "IDX_ROLE_NAME")]
    public partial class SYS_ROLE
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string ROLE_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ROLE_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ROLE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string ROLE_DESC { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? VALID { get; set; }
    }
}
