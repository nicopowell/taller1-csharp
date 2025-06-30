using CargaDeDatosSpace;
using InformeSpace;
using ProcesamientoDeDatosSpace;
using ProductoSpace;

CargaDeDatos cargaDatos = new();

List<Producto> productos = cargaDatos.LeerProductos("Productos.json");

Console.WriteLine("===== PRODUCTOS EN EL SISTEMA =====");
foreach (var producto in productos)
{
    Console.WriteLine($"\nId: {producto.Id}");
    Console.WriteLine($"Titulo: {producto.Titulo}");
    Console.WriteLine($"Descripcion: {producto.Descripcion}");
    Console.WriteLine($"Precio: {producto.Precio}");
    Console.WriteLine($"Porcentaje de Descuento: {producto.PorcentajeDeDescuento}");
    Console.WriteLine($"Rating: {producto.Rating}");
    Console.WriteLine($"Stock: {producto.Stock}");
    Console.WriteLine($"Marca: {producto.Marca}");
    Console.WriteLine($"Categoria: {producto.Categoria}");
}

ProcesamientoDeDatos procesamiento = new();

Informe informe = new();

informe.CantidadDeProductos = procesamiento.ContarProductos(productos);
informe.ProductosSmartPhoneApple = procesamiento.ContarProductosPor(productos, "Apple", "smartphones");
informe.PrecioPromedioLaptop = procesamiento.PrecioPromedio(productos, "", "laptops");
informe.PrecioPromedioSmartphone = procesamiento.PrecioPromedio(productos, "", "smartphones");
informe.BajosDeStock = procesamiento.ProductosAReponer(productos, 49); // Menores a 50
informe.NombreProducto = procesamiento.GetProducto(productos, 5).Titulo;

Console.WriteLine("\n===== INFORME =====");
Console.WriteLine($"Cantidad de productos: {informe.CantidadDeProductos}");
Console.WriteLine($"Cantidad de productos Smartphone Apple: {informe.ProductosSmartPhoneApple}");
Console.WriteLine($"Precio promedio de Laptop: {informe.PrecioPromedioLaptop}");
Console.WriteLine($"Precio promedio de Smartphones: {informe.PrecioPromedioSmartphone}");
Console.WriteLine($"Productos con menos de 50 unidades: ");
foreach (var producto in informe.BajosDeStock)
{
    Console.WriteLine($"\n\tId: {producto.Id}");
    Console.WriteLine($"\tTitulo: {producto.Titulo}");
    Console.WriteLine($"\tDescripcion: {producto.Descripcion}");
    Console.WriteLine($"\tPrecio: {producto.Precio}");
    Console.WriteLine($"\tPorcentaje de Descuento: {producto.PorcentajeDeDescuento}");
    Console.WriteLine($"\tRating: {producto.Rating}");
    Console.WriteLine($"\tStock: {producto.Stock}");
    Console.WriteLine($"\tMarca: {producto.Marca}");
    Console.WriteLine($"\tCategoria: {producto.Categoria}");
}
Console.WriteLine($"Producto de id 5: {informe.NombreProducto}");

cargaDatos.GuardarInforme("Informe.json", informe);