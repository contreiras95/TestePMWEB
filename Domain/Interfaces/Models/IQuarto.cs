using Domain.Entities;
using Domain.Interfaces.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models
{
    public interface IQuarto : IBaseRepository<Quarto>
    {
        /// <summary>Retorna uma lista de quartos de um hotel.</summary>
        /// <param name="hotelId">Codigo de relacionamento ( ID do Hotel )</param>
        public List<Quarto> GetQuartos(int hotelId);
    }
}
