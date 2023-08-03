using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bonachatelectronique.Models
{
    [Table("etat_bon", Schema = "bon_achat")]
    public class EtatBon
    {
        [Key]
        public int Code { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string LibelleParDefaut { get; set; }
        public string Couleur { get; set; }
    }

}
