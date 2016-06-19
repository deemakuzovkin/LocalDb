using System.Data.Entity;
using LocalDb.Data.Entities;

namespace LocalDb.Data.Context
{
    /// <summary>
    /// Локальный контекст базы данных.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class LocalContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public LocalContext()
            : base("LocalDBConnection")
        {

        }

        /// <summary>
        /// Машины.
        /// </summary>
        public DbSet<Car> Cars { get; set; }
    }
}
