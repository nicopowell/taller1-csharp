using ProductoSpace;

namespace InformeSpace
{
    class Informe
    {
        public int CantidadDeProductos { get; set; }
        public int ProductosSmartPhoneApple { get; set; }
        public double PrecioPromedioLaptop { get; set; }
        public double PrecioPromedioSmartphone { get; set; }
        public List<Producto> BajosDeStock { get; set; }
        public string NombreProducto { get; set; }
    }
}
