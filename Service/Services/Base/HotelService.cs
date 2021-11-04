using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Domain.Entities.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Models;
using Domain.Entities;
using Service.Validations;
using FluentValidation.Results;
using Domain.Interfaces.Services.Base;
using MoreLinq;

namespace Service.Services.Base
{
    public class HotelService : IHotelService
    {
        IHotel _IHotel;

        public HotelService(IHotel IHotel)
        {
            _IHotel = IHotel;
        }

        public List<ValidationFailure> Add(Hotel hotel)
        {
            var validator = new HotelValidation();
            var valide = validator.Validate(hotel);

            if (valide.IsValid)
            {
                _IHotel.Add(hotel);
            }

            return valide.Errors.DistinctBy(x => x.PropertyName).ToList();
        }

        public void Delete(Hotel hotel)
        {
            _IHotel.Delete(hotel);
        }

        public Hotel GetEntityById(int Id)
        {
            return _IHotel.GetEntityById(Id);
        }

        public List<Hotel> List()
        {
            return _IHotel.List();
        }

        public List<ValidationFailure> Update(Hotel hotel)
        {
            var validator = new HotelValidation();
            var valide = validator.Validate(hotel);

            if (valide.IsValid)
            {
                _IHotel.Update(hotel);
            }

            return valide.Errors.DistinctBy(x => x.PropertyName).ToList();
        }

        
    }
}
