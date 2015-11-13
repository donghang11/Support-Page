namespace SupportPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("model")]
    public partial class model
    {
        public int id { get; set; }

        [Column("interface")]
        public int _interface { get; set; }

        [Required]
        [StringLength(50)]
        public string cord { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
