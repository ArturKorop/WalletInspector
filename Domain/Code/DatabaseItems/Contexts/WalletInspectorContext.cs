using System.Data.Entity;

namespace Domain.Code.DatabaseItems.Contexts
{
    public class WalletInspectorContext : DbContext
    {
        public DbSet<CostItemForDataBase> CostItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}