using System;
using System.ComponentModel.DataAnnotations;

namespace MaltidRapporter.Models
{
    public class MaltidReport
    {
        [Key]
        public int? Rapport_ID { get; set; }
        public DateTime? Rapport_Datum { get; set; }
        public string Rapport_Anvandare { get; set; }
        public int Antal { get; set; }
        public string Portionstyp_ID { get; set; }
        public string Verksamhet_ID { get; set; }
    }
}
