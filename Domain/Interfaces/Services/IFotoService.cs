using Domain.Entities;
using Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IFotoService 
    {
        /// <summary>Atualiza um conjunto de fotos relacionadas a um objeto.</summary>
        /// <param name="listPhotosClientSide">Lista de fotos para atualizar.</param>
        public void Update(List<Foto> listPhotosClientSide);

        /// <summary>Adicionar uma lista de fotos no banco.</summary>
        /// <param name="photos">Fotos a serem inseridas.</param>
        void Add(List<Foto> photos);

        /// <summary>Retorna uma lista de fotos do banco.</summary>
        /// <param name="codigo">Codigo de relacionamento ( ID do Hotel ou Quarto )</param>
        /// <param name="tipo">Tipo da foto ( Hotel ou Quarto )</param>
        public List<Foto> GetPhotos(int codigo, string tipo);
    }
}
