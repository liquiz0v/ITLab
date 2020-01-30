using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ITLab.Client_Objects;

namespace ITLab.Models
{
    public partial class ITLabContext : DbContext
    {
        public ITLabContext()
        {
        }

        public ITLabContext(DbContextOptions<ITLabContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<FeedbackStatuses> FeedbackStatuses { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }

        public virtual DbSet<ShortNews> ShortNews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=25.69.90.146;Database=ITLab;User ID=sa;Password=LaboratorY1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortNews>().HasNoKey();

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.TimeDate).HasColumnType("datetime");

                entity.HasOne(d => d.Commentator)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentatorId)
                    .HasConstraintName("FK__Comments__Commen__49C3F6B7");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK__Comments__NewsId__4AB81AF0");
            });
           
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FeedbackStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.FeedbackStatusNavigation)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.FeedbackStatus)
                    .HasConstraintName("FK__Feedback__Feedba__4316F928");
            });

            modelBuilder.Entity<FeedbackStatuses>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Statuses)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TimeDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK__Photos__NewsId__398D8EEE");
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK__Videos__NewsId__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
