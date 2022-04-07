using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("GYYT_CS_FUNCIOTN")]
    public partial class GYYT_CS_FUNCIOTN
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string CS_FUNCIOTN_ID { get; set; }
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
        public string FUNCIOTN_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string FUNCTION_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MAX_ICON { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MIN_ICON { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string DLL_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string CLASS_NAME { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? SEQ_NO { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? IS_ENABLE { get; set; }
    }
}
