using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models.Base
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>Adicionar novo objeto no banco.</summary>
        /// <param name="Object">Objeto a ser inserido.</param>
        void Add(T Object);

        /// <summary>Atualiza um objeto no banco.</summary>
        /// <param name="Object">Objeto a ser atualizado.</param>
        void Update(T Object);

        /// <summary>Excluit um objeto do banco.</summary>
        /// <param name="Object">Objeto a ser excluído.</param>
        void Delete(T Object);

        /// <summary>Retorna um objeto específico do banco.</summary>
        /// <param name="ID">ID usado para buscar objeto.</param>
        T GetEntityById(int ID);

        /// <summary>Retorna uma lista de objetos do banco.</summary>
        List<T> List();
    }
}
