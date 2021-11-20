using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.UserInterface
{
    /// <summary>
    /// Serevicio del dominio Categoría
    /// Es aquí donde se implementa la lógica de negocio
    /// </summary>
    public class SdCategoria
    {
        private readonly CategoriaRepository _categoriaRepository = new CategoriaRepository();

        public List<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public void Create(Categoria entity)
        {
            if (entity.Id == 0)
                _categoriaRepository.Create(entity);
            else
                _categoriaRepository.Update(entity);

        }

        public Categoria Single(int id)
        {
            return _categoriaRepository.Single(id);
        }

        public void Delete(int id)
        {
            _categoriaRepository.Delete(id);
        }
    }
}
