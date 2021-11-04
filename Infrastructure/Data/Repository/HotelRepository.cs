using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Models;
using Infrastructure.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class HotelRepository : BaseRepository<Hotel>, IHotel
    {
    }
}
