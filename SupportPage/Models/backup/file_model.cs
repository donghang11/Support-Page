namespace SupportPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Files")]
    public partial class file_model
    {
        public int id { get; set; }

        public int sender { get; set; }

        public int incident { get; set; }

        [Required]
        [StringLength(128)]
        public string name { get; set; }

        [StringLength(256)]
        public string fpath { get; set; }


        [StringLength(2048)]
        public string note { get; set; }

        [Column(TypeName = "date")]
        public DateTime dt { get; set; }
    }
}
