using Domain.Entities;
using Domain.Interfaces.Models;
using Domain.Interfaces.Services;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Base
{
    public class FotoService : IFotoService
    {
        IFoto _IFoto;

        public FotoService(IFoto IFoto)
        {
            _IFoto = IFoto;
        }

        public void Add(List<Foto> obj)
        {
            obj.ForEach(x => _IFoto.Add(x));
        }

        public void Update(List<Foto> obj)
        {
            _IFoto.UpdatePhotos(obj);
        }

        public List<Foto> GetPhotos(int codigo, string tipo)
        {
            return _IFoto.EspecificPhotoList(codigo, tipo);
        }
    }
}
