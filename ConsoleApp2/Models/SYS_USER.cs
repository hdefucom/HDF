using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_USER")]
    [Index("DEPT_CODE", Name = "IDX_DEPT_CODE2")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE2")]
    [Index("REAL_NAME", Name = "IDX_REAL_NAME")]
    [Index("USER_NAME", Name = "IDX_USER_NAME")]
    public partial class SYS_USER
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string USER_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string DEPT_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string USER_NAME { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string REAL_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string PASSWORD { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string ID_NO { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string GENDER_CODE { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? BIRTH_DATE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string TEL_NO { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MOBILE_NO { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string EMAIL { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string HOME_ADDR { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? JOIN_DATE { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? LEAVE_DATE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MARRIAGE_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string POSITION_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string RANK_CODE { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string DDUCATION_CODE { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? ORDER_NO { get; set; }
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
        [StringLength(300)]
        [Unicode(false)]
        public string GENDER_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MARRIAGE_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string POSITION_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string RANK_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string DDUCATION_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string DEPT_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string AGE { get; set; }
        [Column(TypeName = "NUMBER(38)")]
        public decimal? WORK_AGE { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string OPENID { get; set; }
        [Column(TypeName = "CLOB")]
        public string SIGNATURE { get; set; }
    }
}
