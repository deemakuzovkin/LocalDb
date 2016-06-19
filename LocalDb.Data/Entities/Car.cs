using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalDb.Data.Entities
{
    /// <summary>
    /// Объект машины.
    /// </summary>
    [Table("Cars")]
    public class Car
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Car()
        {

        }

        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Название машины.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Гос. номер.
        /// </summary>
        public string Number { get; set; }
    }
}
