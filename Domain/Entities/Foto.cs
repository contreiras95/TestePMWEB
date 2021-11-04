using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Foto : BaseEntity
    {
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "Arquivo")]
        public string Arquivo { get; set; }

        [Display(Name = "Código Relacionamento")]
        public int Codigo { get; set; }
    }
}
