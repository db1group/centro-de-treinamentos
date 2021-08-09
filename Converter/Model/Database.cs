using Microsoft.EntityFrameworkCore;

namespace Converter.Model
{
    public class Database : DbContext
    {
        private readonly string _databaseFileName;
        
        public Database(string databaseFileName)
        {
            _databaseFileName = databaseFileName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseJet($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_databaseFileName};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapCompetence(modelBuilder);
            MapTrack(modelBuilder);
            MapObjective(modelBuilder);
            MapLearnable(modelBuilder);
            MapContent(modelBuilder);
        }

        private static void MapContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().ToTable("Content");

            modelBuilder.Entity<Content>().Property(x => x.Learnable);
            modelBuilder.Entity<Content>().Property(x => x.Description);
            modelBuilder.Entity<Content>().Property(x => x.Type);
            modelBuilder.Entity<Content>().Property(x => x.Language);
            modelBuilder.Entity<Content>().Property(x => x.Order);
            modelBuilder.Entity<Content>().Property(x => x.Link).HasConversion(x => x, x => x.Trim('#'));
        }

        private static void MapLearnable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Learnable>().Property(x => x.Objective);
            modelBuilder.Entity<Learnable>().Property(x => x.Name);
            modelBuilder.Entity<Learnable>()
                .ToTable("Learnable")
                .HasMany(c => c.Contents)
                .WithOne()
                .HasForeignKey(t => t.Learnable);
        }

        private static void MapObjective(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objective>().Property(x => x.Track);
            modelBuilder.Entity<Objective>().Property(x => x.Name);
            modelBuilder.Entity<Objective>().Property(x => x.Level);
            modelBuilder.Entity<Objective>()
                .ToTable("Objective")
                .HasMany(c => c.Learnables)
                .WithOne()
                .HasForeignKey(t => t.Objective);
        }

        private static void MapTrack(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().Property(x => x.Competence);
            modelBuilder.Entity<Track>().Property(x => x.Name);
            modelBuilder.Entity<Track>().Property(x => x.Goal);
            modelBuilder.Entity<Track>().ToTable("Track")
                .HasMany(c => c.Objectives)
                .WithOne()
                .HasForeignKey(t => t.Track);
        }
        
        private static void MapCompetence(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competence>().Property(x => x.Name);
            modelBuilder.Entity<Competence>()
                .ToTable("Competence")
                .HasMany(c => c.Tracks)
                .WithOne()
                .HasForeignKey(t => t.Competence);
        }
    }
}