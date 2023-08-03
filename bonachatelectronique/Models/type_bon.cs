using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bonachatelectronique.Models
{
    [Table("type_bon", Schema = "bon_achat")]
    public class TypeBon
    {
        [Key]
        public int Code { get; set; }
        public string Libelle { get; set; }
    }
}
