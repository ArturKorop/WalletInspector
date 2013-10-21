using System.Data.Entity;
using Domain.Code.General;

namespace Domain.Code.DatabaseItems
{
    public class WalletInspectorContext : DbContext
    {
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}