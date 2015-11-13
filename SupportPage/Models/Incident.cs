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

        public int? model { get; set; }

        public string description { get; set; }

        public int drafter { get; set; }

        public DateTime reportdate { get; set; }

        public int? sales { get; set; }

        public int? supportteam { get; set; }

        public int? technote { get; set; }

        public int? instruction { get; set; }

        public int? faq { get; set; }

        public int? allcompany { get; set; }

        public string other { get; set; }

        public int? handler { get; set; }

        public DateTime enddate { get; set; }

        public DateTime lastupdatedate { get; set; }

        public int? parent { get; set; }

        [StringLength(128)]
        public string cusname { get; set; }

        [StringLength(128)]
        public string discom { get; set; }

        [StringLength(128)]
        public string cuscom { get; set; }

        [StringLength(128)]
        public string dispname { get; set; }
    }
}
