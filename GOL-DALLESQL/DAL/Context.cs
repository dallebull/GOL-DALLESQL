namespace GOL_DALLESQL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=GolDB")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>());
            Database.SetInitializer(new GameArray.GameArrayDBInitializer());
        }

        public virtual DbSet<GameArray> GameArrays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameArray>()
                .Property(e => e.GameArrayID);
                

            modelBuilder.Entity<GameArray>()
                .Property(e => e.Seed)
                .IsFixedLength();

            modelBuilder.Entity<GameArray>()
                .Property(e => e.Name)
                .IsFixedLength();
            modelBuilder.Entity<GameArray>()
                .Property(e => e.NextTurn)
                .IsFixedLength();
        }
    }
}
