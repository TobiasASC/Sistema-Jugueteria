using System;
using System.Data;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class ProductoBusiness
    {
        // Instancia de la clase ProductoData para acceder a los métodos de la capa de datos
        private ProductoData _productoData = new ProductoData();

        // Métodos de negocio para la gestión de productos
        // Estos métodos interactúan con la capa de datos y aplican reglas de negocio antes de realizar operaciones en la base de datos
        public DataTable ListarProductos(bool verSoloInactivos)
        {
            return _productoData.Listar(verSoloInactivos);
        }

        // Método para registrar un nuevo producto
        public string RegistrarProducto(Producto obj)
        {
            // Validar los datos del producto antes de insertarlo
            string mensajeValidacion = ValidarProducto(obj);
            if (mensajeValidacion != "OK") return mensajeValidacion;

            // Verificar si el producto ya existe antes de insertarlo (id_producto)
            if (_productoData.ExisteProducto(obj.IdProducto))
            {
                return $"Ya existe un producto registrado con el código '{obj.IdProducto}'. Ingrese uno diferente.";
            }

            // Insertar el producto en la base de datos
            bool respuesta = _productoData.Insertar(obj);
            return respuesta ? "Producto registrado correctamente." : "Error al registrar el producto en la base de datos.";
        }

        // Método para modificar un producto existente
        public string ModificarProducto(Producto obj)
        {
            string mensajeValidacion = ValidarProducto(obj);
            if (mensajeValidacion != "OK") return mensajeValidacion;

            bool respuesta = _productoData.Actualizar(obj);
            return respuesta ? "Producto modificado correctamente." : "Error al modificar el producto.";
        }

        // Método para eliminar un producto (baja lógica)
        public string EliminarProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto)) return "Debe seleccionar un producto para dar de baja.";

            bool respuesta = _productoData.Eliminar(idProducto);
            return respuesta ? "Producto dado de baja exitosamente." : "Error al dar de baja el producto.";
        }

        // Método para validar los datos del producto antes de realizar operaciones en la base de datos
        private string ValidarProducto(Producto obj)
        {
            if (string.IsNullOrWhiteSpace(obj.IdProducto)) return "El código del producto es obligatorio.";
            if (string.IsNullOrWhiteSpace(obj.Descripcion)) return "La descripción no puede estar vacía.";
            if (obj.PrecioVenta <= 0) return "El precio de venta debe ser mayor a 0.";
            if (obj.IdCategoria <= 0) return "Debe seleccionar una categoría válida.";
            if (obj.StockMinimo < 0 || obj.StockActual < 0) return "El stock no puede ser negativo.";

            return "OK";
        }

        // Método para reactivar un producto previamente eliminado (baja lógica)
        public string ReactivarProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto)) return "Debe seleccionar un producto para reactivar.";

            bool respuesta = _productoData.Reactivar(idProducto);
            return respuesta ? "Producto reactivado exitosamente." : "Error al reactivar el producto.";
        }

        // Método para obtener un producto activo por su ID
        public Producto ObtenerProductoActivo(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto)) return null;
            return _productoData.ObtenerProductoActivo(idProducto);
        }

        // Método para listar productos activos para sugerencias en la busqueda de productos 
        public List<Producto> ListarProductosParaSugerencias()
        {
            return _productoData.ListarProductosParaSugerencias();
        }

        // Método para obtener un producto activo por su descripción
        public Producto ObtenerProductoActivoPorDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion)) return null;
            return _productoData.ObtenerProductoActivoPorDescripcion(descripcion);
        }
    }
}