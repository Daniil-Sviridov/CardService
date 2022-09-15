using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardStorageService.Data
{
    [Table("Client")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Column]
        [StringLength(255)]
        public string? Surname { get; set; }

        [Column]
        [StringLength(255)]
        public string? FirstName { get; set; }

        [Column]
        [StringLength(255)]
        public string? Patronymic { get; set; }

        [InverseProperty(nameof(Cards.Client))]
        public virtual ICollection<Cards> Card { get; set; } = new HashSet<Cards>();
    }
}
