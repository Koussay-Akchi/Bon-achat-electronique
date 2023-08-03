using System.ComponentModel.DataAnnotations.Schema;

namespace bonachatelecronique.data.Models
{
    [Table("bon_achat_electronique", Schema = "bon_achat")]
    public class BonAchatElectronique
    {
        public int Id { get; set; }
        public int IdUtilisateur { get; set; }
        public long SoldeCarteUtilisateurAvant { get; set; }
        public long SoldeCarteUtilisateurApres { get; set; }
        public DateTime DateGeneration { get; set; }
        public int CodeEtat { get; set; }
        public int CodeType { get; set; }
        public long ValeurInitiale { get; set; }
        public long ValeurRestante { get; set; }
        public string EmailBeneficiaire { get; set; }
        public int TelephoneBeneficiaire { get; set; }
        public int CodeSource { get; set; }
        
    }
}
