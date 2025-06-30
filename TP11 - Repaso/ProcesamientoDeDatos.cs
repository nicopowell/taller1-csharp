using ProductoSpace;

namespace ProcesamientoDeDatosSpace
{
    class ProcesamientoDeDatos
    {
        public int ContarProductos(List<Producto> productos)
        {
            return productos.Count;
        }

        public int ContarProductosPor(List<Producto> productos, string marca, string categoria)
        {
            return productos.Count(producto => producto.Marca == marca && producto.Categoria == categoria);
        }

        public double PrecioPromedio(List<Producto> productos, string marca, string categoria)
        {
            double suma = 0;
            int cantidad = 0;

            foreach (var producto in productos)
            {
                bool coincideMarca = string.IsNullOrEmpty(marca) || producto.Marca == marca;
                if (coincideMarca && producto.Categoria == categoria)
                {
                    suma += producto.Precio;
                    cantidad++;
                }
            }

            if (cantidad == 0)
                return 0;

            return suma / cantidad;
        }

        public List<Producto> ProductosAReponer(List<Producto> productos, int stock)
        {
            return productos.Where(producto => producto.Stock <= stock).ToList();
        }

        public Producto GetProducto(List<Producto> productos, int id)
        {
            return productos.Find(producto => producto.Id == id);
        }
    }
}
