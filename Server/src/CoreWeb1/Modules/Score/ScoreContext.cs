using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CoreWeb1.Modules.Score
{
    /// <summary>
    /// Defines our database.
    /// </summary>
    public class ScoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Here we configure our persistence layer
            //we are using SQLITE because it is fast and local
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "CoreWeb1.db"
            };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }

        /// <summary>
        /// Defines a single table of scores
        /// </summary>
        public DbSet<ScoreModel> Scores { get; set; }
    }
}
