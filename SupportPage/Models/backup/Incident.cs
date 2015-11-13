namespace SupportPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Incident")]
    public partial class Incident
    {
        public int id { get; set; }

        [Column("interface")]
        [StringLength(50)]
        public string _interface { get; set; }

        public string description { get; set; }

        public int drafter { get; set; }

        [Column(TypeName = "date")]
        public DateTime reportdate { get; set; }

        public bool isclosed { get; set; }

        public int? sales { get; set; }

        public int? supportteam { get; set; }

        public int? technote { get; set; }

        public int? instruction { get; set; }

        public int? faq { get; set; }

        public int? allcompany { get; set; }

        public string other { get; set; }

        public int? attachment { get; set; }

        public int? handler { get; set; }

        [Column(TypeName = "date")]
        public DateTime enddate { get; set; }

        [Column(TypeName = "date")]
        public DateTime lastupdatedate { get; set; }

        public int? parent { get; set; }

        public string cusname { get; set; }

        public string discom { get; set; }
    }
}
