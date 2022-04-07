using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("SYS_LOGINFO")]
    public partial class SYS_LOGINFO
    {
        [Key]
        [StringLength(300)]
        [Unicode(false)]
        public string ID { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string USER_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string REAL_NAME { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string MENU_NAME { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string OPERATION { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? OPERATE_TIME { get; set; }
    }
}
