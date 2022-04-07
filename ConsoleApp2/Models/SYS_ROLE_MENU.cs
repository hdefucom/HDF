using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_ROLE_MENU")]
    [Index("ORG_CODE", Name = "IDX_ORG_CODE6")]
    public partial class SYS_ROLE_MENU
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string RELATION_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ORG_CODE { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string ROLE_ID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_ID { get; set; }
    }
}
