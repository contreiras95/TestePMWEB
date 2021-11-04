using Domain.Entities;
using Domain.Interfaces.Models;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class QuartoRepository : BaseRepository<Quarto>, IQuarto
    {
        public QuartoRepository()
        {
            _sqlContext = new DbContextOptions<SQLContext>();
        }

        /// <summary>Retorna uma lista de quartos de um hotel.</summary>
        /// <param name="hotelId">Codigo de relacionamento ( ID do Hotel )</param>
        public List<Quarto> GetQuartos(int hotelId)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                return data.Set<Quarto>().Where(x => x.HotelID == hotelId).ToList();
            }
        }
    }
}
