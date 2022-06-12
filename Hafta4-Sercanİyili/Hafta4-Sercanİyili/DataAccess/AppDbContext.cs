using Hafta4_Sercanİyili.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hafta4_Sercanİyili.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendshipStatus> FriendshipStatuses { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
       // public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<UserMessageHistory> UserMessageHistories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMembership> Memberships { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupMessageHistory> GroupMessageHistories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendshipsApprovement> FriendshipsApprovements { get; set; }

    }
}
