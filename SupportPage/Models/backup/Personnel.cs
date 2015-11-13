namespace SupportPage.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Personnel : DbContext
    {
        public Personnel()
            : base("name=Personnel")
        {
        }

        public virtual DbSet<member_model> members { get; set; }
        public virtual DbSet<org_model> orgs { get; set; }
        public virtual DbSet<person_model> people { get; set; }
        public virtual DbSet<role_model> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
