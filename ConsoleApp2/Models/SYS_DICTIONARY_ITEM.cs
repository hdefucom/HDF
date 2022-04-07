using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_DICTIONARY_ITEM")]
    [Index("DICT_CODE", Name = "IDX_DICT_CODE")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE9")]
    public partial class SYS_DICTIONARY_ITEM
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string DICT_ITEM_ID { get; set; }
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
        public string DICT_ITEM_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string DICT_ITEM_NAME { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? ORDER_NO { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PY_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string WB_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string YB_CODE { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? VALID { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string TYPE_CODE { get; set; }
        [StringLength(3000)]
        [Unicode(false)]
        public string REMARK { get; set; }
    }
}
