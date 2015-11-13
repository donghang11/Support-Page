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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
