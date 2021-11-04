using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Display(Name = "Código", Order = 1)]
        public virtual int ID { get; set; }

        [Display(Name = "Nome", Order = 2)]
        public virtual string Nome { get; set; }
    }
}
