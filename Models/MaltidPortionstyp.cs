using System;
using System.ComponentModel.DataAnnotations;

namespace MaltidRapporter.Models
{
    public class MaltidPortionstyp
    {
        [Key]
        public string Portionstyp_ID { get; set; }
        public string Kategori { get; set; }
        public string Portionstyp { get; set; }
        public decimal Pris { get; set; }
    }
}
