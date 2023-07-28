using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketApp.Models;

public partial class MovieAppContext : DbContext
{
    public MovieAppContext()
    {
    }

    public MovieAppContext(DbContextOptions<MovieAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("DaneDoLaczeniaZBaza");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("bookings_pkey");

            entity.ToTable("bookings");

            entity.Property(e => e.Bookingid).HasColumnName("bookingid");
            entity.Property(e => e.Iscancelled)
                .HasDefaultValueSql("false")
                .HasColumnName("iscancelled");
            entity.Property(e => e.Numofseats).HasColumnName("numofseats");
            entity.Property(e => e.Showtimeid).HasColumnName("showtimeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Showtimeid)
                .HasConstraintName("bookings_showtimeid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("bookings_userid_fkey");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Movieid).HasName("movies_pkey");

            entity.ToTable("movies");

            entity.Property(e => e.Movieid).HasColumnName("movieid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Poster)
                .HasMaxLength(255)
                .HasColumnName("poster");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Showtimeid).HasName("showtimes_pkey");

            entity.ToTable("showtimes");

            entity.Property(e => e.Showtimeid).HasColumnName("showtimeid");
            entity.Property(e => e.Movieid).HasColumnName("movieid");
            entity.Property(e => e.Startdatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdatetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.Movieid)
                .HasConstraintName("showtimes_movieid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isadmin)
                .HasDefaultValueSql("false")
                .HasColumnName("isadmin");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
