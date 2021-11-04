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
    public class FotoRepository : BaseRepository<Foto>, IFoto
    {
        public FotoRepository()
        {
            _sqlContext = new DbContextOptions<SQLContext>();
        }

        /// <summary>Retorna uma lista de fotos do banco.</summary>
        /// <param name="codigo">Codigo de relacionamento ( ID do Hotel ou Quarto )</param>
        /// <param name="tipo">Tipo da foto ( Hotel ou Quarto )</param>
        public List<Foto> EspecificPhotoList(int codigo, string tipo)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                return data.Set<Foto>().Where(x=> x.Codigo == codigo && x.Tipo == tipo).ToList();
            }
        }

        /// <summary>Atualiza um conjunto de fotos relacionadas a um objeto.</summary>
        /// <param name="listPhotosClientSide">Lista de fotos para atualizar.</param>
        public void UpdatePhotos(List<Foto> listPhotosClientSide)
        {
            Foto photo = listPhotosClientSide.FirstOrDefault();

            var listPhotosServer = EspecificPhotoList(photo.Codigo, photo.Tipo);

            foreach(var photoServer in listPhotosServer)
            {
                bool excluir = true;

                foreach (var photoClient in listPhotosClientSide.Where(x => x.ID != 0).ToList())
                {
                    if (photoClient.ID == photoServer.ID)
                    {
                        excluir = false;
                    }
                }

                if(excluir == true)
                {
                    using (var data = new SQLContext(_sqlContext))
                    {
                        data.Set<Foto>().Remove(photoServer);
                        data.SaveChanges();
                    }
                }
            }

            var newPhotos = listPhotosClientSide.Where(x => x.ID == 0).ToList();

            foreach(var item in newPhotos)
            {
                using (var data = new SQLContext(_sqlContext))
                {
                    data.Set<Foto>().Add(item);
                    data.SaveChanges();
                }
            }
        }
    }
}
