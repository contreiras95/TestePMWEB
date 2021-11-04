using Domain.Entities;
using Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IQuartoService : IBaseService<Quarto>
    {
        /// <summary>Retorna uma lista de quartos de um hotel.</summary>
        /// <param name="hotelId">Codigo de relacionamento ( ID do Hotel )</param>
        public List<Quarto> GetQuartos(int hotelId);
    }
}
