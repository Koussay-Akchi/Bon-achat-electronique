﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bonachatelectronique.Models
{
    [Table("source_bon", Schema = "bon_achat")]
    public class SourceBon
    {
        [Key]
        public int Code { get; set; }
        public string Libelle { get; set; }
    }
}
