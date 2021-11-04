using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Models.Base;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        public DbContextOptions<SQLContext> _sqlContext;

        public BaseRepository()
        {
            _sqlContext = new DbContextOptions<SQLContext>();
        }

        /// <summary>Adicionar novo objeto no banco.</summary>
        /// <param name="obj">Objeto a ser inserido.</param>
        public void Add(T obj)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                data.Set<T>().Add(obj);
                data.SaveChanges();
            }
        }

        /// <summary>Exclui um objeto no banco.</summary>
        /// <param name="obj">Objeto a ser excluído.</param>
        public void Delete(T obj)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                data.Set<T>().Remove(obj);
                data.SaveChanges();
            }
        }

        /// <summary>Retorna um objeto do banco.</summary>
        /// <param name="id">Identificador usado para buscar objeto.</param>
        public T GetEntityById(int id)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                return data.Set<T>().Find(id);
            }
        }

        /// <summary>Retorna uma lista de objetos do banco.</summary>
        public List<T> List()
        {
            using (var data = new SQLContext(_sqlContext))
            {
                return data.Set<T>().AsNoTracking().ToList();
            }
        }

        /// <summary>Atualiza um objeto no banco.</summary>
        /// <param name="obj">Objeto a ser atualizado.</param>
        public void Update(T obj)
        {
            using (var data = new SQLContext(_sqlContext))
            {
                data.Set<T>().Update(obj);
                data.SaveChanges();
            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

    }
}
