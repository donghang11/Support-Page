namespace SupportPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("member")]
    public partial class member_model
    {
        public int id { get; set; }

        public int person { get; set; }

        public int org { get; set; }

        public int role { get; set; }

        [Column(TypeName = "date")]
        public DateTime sd { get; set; }

        [Column(TypeName = "date")]
        public DateTime ed { get; set; }
    }
}
