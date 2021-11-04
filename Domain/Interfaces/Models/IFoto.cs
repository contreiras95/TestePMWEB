using Domain.Entities;
using Domain.Interfaces.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models
{
    public interface IFoto : IBaseRepository<Foto>
    {
        /// <summary>Retorna uma lista de fotos do banco.</summary>
        /// <param name="codigo">Codigo de relacionamento ( ID do Hotel ou Quarto )</param>
        /// <param name="tipo">Tipo da foto ( Hotel ou Quarto )</param>
        public List<Foto> EspecificPhotoList(int codigo, string tipo);

        /// <summary>Atualiza um conjunto de fotos relacionadas a um objeto.</summary>
        /// <param name="listPhotosClientSide">Lista de fotos para atualizar.</param>
        public void UpdatePhotos(List<Foto> listPhotosClientSide);
    }
}
