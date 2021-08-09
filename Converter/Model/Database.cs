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
            MapSkill(modelBuilder);
            MapTrack(modelBuilder);
            MapObjective(modelBuilder);
            MapLearnable(modelBuilder);
            MapContent(modelBuilder);
        }

        private static void MapContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().ToTable("Material");

            modelBuilder.Entity<Content>().Property(x => x.Learnable).HasColumnName("Aprendivel");
            modelBuilder.Entity<Content>().Property(x => x.Description).HasColumnName("Descricao");
            modelBuilder.Entity<Content>().Property(x => x.Type).HasColumnName("Tipo");
            modelBuilder.Entity<Content>().Property(x => x.Language).HasColumnName("Idioma");
            modelBuilder.Entity<Content>().Property(x => x.Order).HasColumnName("Ordem");
            modelBuilder.Entity<Content>().Property(x => x.Link).HasColumnName("Link")
                .HasConversion(x => x, x => x.Trim('#'));
        }

        private static void MapLearnable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Learnable>().Property(x => x.Objective).HasColumnName("Objetivo");
            modelBuilder.Entity<Learnable>().Property(x => x.Name).HasColumnName("Nome");
            modelBuilder.Entity<Learnable>()
                .ToTable("Aprendivel")
                .HasMany(c => c.Contents)
                .WithOne()
                .HasForeignKey(t => t.Learnable);
        }

        private static void MapObjective(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objective>().Property(x => x.Track).HasColumnName("Trilha");
            modelBuilder.Entity<Objective>().Property(x => x.Name).HasColumnName("Nome");
            modelBuilder.Entity<Objective>().Property(x => x.Level).HasColumnName("Nivel");
            modelBuilder.Entity<Objective>()
                .ToTable("Objetivo")
                .HasMany(c => c.Learnables)
                .WithOne()
                .HasForeignKey(t => t.Objective);
        }

        private static void MapTrack(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().Property(x => x.Skill).HasColumnName("Competencia");
            modelBuilder.Entity<Track>().Property(x => x.Name).HasColumnName("Nome");
            modelBuilder.Entity<Track>().Property(x => x.Objective).HasColumnName("Objetivo");
            modelBuilder.Entity<Track>().ToTable("Trilha")
                .HasMany(c => c.Objectives)
                .WithOne()
                .HasForeignKey(t => t.Track);
        }
        
        private static void MapSkill(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().Property(x => x.Name).HasColumnName("Nome");
            modelBuilder.Entity<Skill>()
                .ToTable("Competencia")
                .HasMany(c => c.Tracks)
                .WithOne()
                .HasForeignKey(t => t.Skill);
        }
    }
}