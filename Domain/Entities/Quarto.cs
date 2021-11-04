using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quarto : BaseEntity
    {
        [Display(Name = "Código do Hotel")]
        public int HotelID { get; set; }

        [Display(Name = "Número de Ocupantes")]
        public int NumeroOcupantes { get; set; }

        [Display(Name = "Número de Adultos")]
        public int NumeroAdultos { get; set; }

        [Display(Name = "Número de Crianças")]
        public int NumeroCriancas { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [NotMapped]
        public List<Foto> Fotos { get; set; }
    }
}
