using Socialno.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Socialno.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Friendship> Friendships { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Message>()
            .HasKey(p => p.Id);


        builder.Entity<Message>()
            .Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();


        builder.Entity<User>()
            .Property(b => b.AvatarUrl)
            .HasDefaultValue("no_profile_image.png");

        builder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.AuthorId);

        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Comment>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.AuthorId);

      

        builder.Entity<Friendship>()
            .HasKey(f => new { f.UserId, f.FriendId });

        builder.Entity<Friendship>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId);

        builder.Entity<Friendship>()
            .HasOne(f => f.Friend)
            .WithMany()
            .HasForeignKey(f => f.FriendId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    
}