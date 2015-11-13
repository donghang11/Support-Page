namespace SupportPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Action")]
    public partial class action_model
    {
        public int id { get; set; }

        public DateTime dt { get; set; }

        public int incident { get; set; }

        public int sender { get; set; }


        [StringLength(512)]
        public string receiver { get; set; }

        public string description { get; set; }
    }
}
