using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models
{
    [Table("D_TEST")]
    public partial class D_TEST
    {
        [Key]
        [StringLength(10)]
        [Unicode(false)]
        public string Q { get; set; }
    }
}
