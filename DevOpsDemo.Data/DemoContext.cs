using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using DevOpsDemo.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Infrastructure;

namespace DevOpsDemo.Data
{
    public partial class DemoContext : DbContext
    {
        public DemoContext() : base("DemoContext")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Movie)
                .WithMany(e => e.Actor)
                .Map(m => m.ToTable("MovieActor").MapLeftKey("ActorID").MapRightKey("MovieID"));

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Rating)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);
        }
    }
}
