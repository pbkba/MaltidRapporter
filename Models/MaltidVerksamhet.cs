using System;
using System.ComponentModel.DataAnnotations;

namespace MaltidRapporter.Models
{
    public class MaltidVerksamhet
    {
        [Key]
        public int ID { get; set; }
        public string Verksamhet_ID { get; set; }
        public string Forvaltning { get; set; }
        public string Kundkod { get; set; }
        public string Gruppnamn { get; set; }
        public string Namn { get; set; }
        public int Ansvar { get; set; }
        public int Verksamhet { get; set; }
        public int Aktivitet { get; set; }
        public int Motpart { get; set; }
        public int KokAnsvar { get; set; }
        public int TKKok { get; set; }
    }
}
