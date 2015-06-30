using Domain.FriendshipDomain;
using Domain.PostDomain;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class FriendshipContext : DbContext
    {
        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>().ToTable("TBFriendship").Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Post>().ToTable("TBPost").Property(x => x.Message)
                .IsRequired().HasMaxLength(300);

            modelBuilder.Entity<Post>().ToTable("TBPost").Property(x => x.Name)
                .IsRequired();
        }
    }
}