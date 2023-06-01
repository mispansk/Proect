using System.ComponentModel.DataAnnotations.Schema;

namespace final5.Models
{
    /// <summary>
    /// класс "Роль"
    /// </summary>
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
