using Microsoft.EntityFrameworkCore;

namespace CoreWeb1.Data
{
    /// <summary>
    /// Defines our database.
    /// </summary>
    public class ScoreContext : DbContext
    {
        /// <summary>
        /// Defines a single table of scores
        /// </summary>
        public DbSet<ScoreModel> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO move to startup
            optionsBuilder.UseSqlite("Filename=./score.db");
        }
    }
}
