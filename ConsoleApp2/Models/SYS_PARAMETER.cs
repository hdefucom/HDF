using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_PARAMETER")]
    public partial class SYS_PARAMETER
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string PARAMETER_ID { get; set; }
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
        public DateTime? MODEIFY_TIME { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? VALID { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PARA_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PARA_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PARA_MEAN { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PARA_VALUE { get; set; }
    }
}
