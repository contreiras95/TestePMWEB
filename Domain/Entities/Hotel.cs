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
    public class Hotel : BaseEntity
    {
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [NotMapped]
        public List<Foto> Fotos { get; set; }

        [NotMapped]
        public List<Quarto> Quartos { get; set; }
    }
}
