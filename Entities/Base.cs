using Entities.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Base : Notify
    {
        [Display(Name = "Código", Order = 1)]
        public int ID { get; set; }

        [Display(Name = "Nome", Order = 2)]
        public string Nome { get; set; }
    }
}
