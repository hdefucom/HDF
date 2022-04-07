using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_DICTIONARY")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE8")]
    [Index("DICT_CODE", Name = "WY_DICT_CODE", IsUnique = true)]
    public partial class SYS_DICTIONARY
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string DICT_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string DICT_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string DICT_NAME { get; set; }
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
        [Column(TypeName = "NUMBER(38)")]
        public decimal? VALID { get; set; }
    }
}
