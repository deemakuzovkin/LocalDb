using System.ComponentModel.DataAnnotations.Schema;

namespace LocalDb.Data.Entities
{
    /// <summary>
    /// Объект сущности справочника книг.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Book()
        {
        }

        [Column("Название")]
        public string Name { get; set; }
    }
}
