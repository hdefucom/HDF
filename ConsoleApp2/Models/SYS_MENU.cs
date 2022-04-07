using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_MENU")]
    [Index("MENU_CODE", "CLIENT_TYPE", Name = "AK_KEY_2_SYS_MENU", IsUnique = true)]
    [Index("MENU_CODE", Name = "IDX_MENU_CODE")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE3")]
    [Index("PARENT_ID", Name = "IDX_PARENT_ID")]
    public partial class SYS_MENU
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_TYPE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PARENT_ID { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PATH { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string ICON { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string COMPONENT { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string TARGET { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string REDIRECT { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string KEEP_ALIVE { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? HIDDEN { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? ORDER_NO { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string REMARK { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? CLIENT_TYPE { get; set; }
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
        [Column(TypeName = "NUMBER(38)")]
        public decimal? IS_HIDDEN { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? KEEPALIVE { get; set; }
    }
}
