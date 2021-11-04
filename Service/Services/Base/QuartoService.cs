using Domain.Entities;
using Domain.Interfaces.Models;
using Domain.Interfaces.Services;
using FluentValidation.Results;
using MoreLinq;
using Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Base
{
    public class QuartoService : IQuartoService
    {
        IQuarto _IQuarto;

        public QuartoService(IQuarto IHotel)
        {
            _IQuarto = IHotel;
        }

        public List<ValidationFailure> Add(Quarto quarto)
        {
            var validator = new QuartoValidation();
            var valide = validator.Validate(quarto);

            if (valide.IsValid)
            {
                _IQuarto.Add(quarto);
            }

            return valide.Errors.DistinctBy(x => x.PropertyName).ToList();
        }

        public void Delete(Quarto quarto)
        {
            _IQuarto.Delete(quarto);
        }

        public Quarto GetEntityById(int Id)
        {
            return _IQuarto.GetEntityById(Id);
        }

        public List<Foto> GetQuartos(int hotelId)
        {
            throw new NotImplementedException();
        }

        public List<Quarto> List()
        {
            return _IQuarto.List();
        }

        public List<ValidationFailure> Update(Quarto quarto)
        {
            var validator = new QuartoValidation();
            var valide = validator.Validate(quarto);

            if (valide.IsValid)
            {
                _IQuarto.Update(quarto);
            }

            return valide.Errors.DistinctBy(x => x.PropertyName).ToList();
        }

        List<Quarto> IQuartoService.GetQuartos(int hotelId)
        {
            return _IQuarto.GetQuartos(hotelId);
        }
    }
}
