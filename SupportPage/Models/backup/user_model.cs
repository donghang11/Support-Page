namespace SupportPage.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class user_model : DbContext
    {
        public user_model()
            : base("name=user_model")
        {
        }

        public virtual DbSet<admin_user> users { get; set; }
        public virtual DbSet<admin_role> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin_role>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
