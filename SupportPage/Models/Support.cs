namespace SupportPage.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Support : DbContext
    {
        public Support()
            : base("name=Support")
        {
        }

        public virtual DbSet<action_model> Actions { get; set; }
        public virtual DbSet<file_model> Files { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<model> models { get; set; }
        public virtual DbSet<org> orgs { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<acctype> acctypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<model>()
                .Property(e => e.cord)
                .IsUnicode(false);

            modelBuilder.Entity<acctype>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
