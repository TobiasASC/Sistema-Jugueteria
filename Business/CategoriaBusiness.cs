using System.Collections.Generic;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class CategoriaBusiness
    {
        private CategoriaData _categoriaData = new CategoriaData();

        public List<Categoria> ListarCategoriasActivas()
        {
            return _categoriaData.ListarCategoriasActivas();
        }
    }
}