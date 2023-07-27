using Microsoft.EntityFrameworkCore;

namespace PoolLog.Models
{
    public class PoolContext : DbContext
    {
        public DbSet<Pool> Pools { get; set; } = null!;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PoolContext"/> class.
        /// </summary>
        /// <param name="options">The context options.</param>
        public PoolContext(DbContextOptions<PoolContext> options)
            : base(options)
        {
        }
    }
}
