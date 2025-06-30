using System.Text.Json;
using System.Threading.Tasks;
using InformeSpace;
using ProductoSpace;

namespace CargaDeDatosSpace
{
    class CargaDeDatos
    {
        public List<Producto> LeerProductos(string nombreArchivo)
        {
            try
            {
                string json = File.ReadAllText(nombreArchivo);
                var productos = JsonSerializer.Deserialize<List<Producto>>(json);
                return productos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer el JSON " + e);
                return [];
            }

        }

        public async Task GuardarInforme(string nombreArchivo, Informe informe)
        {
            string json = JsonSerializer.Serialize(informe);
            await File.WriteAllTextAsync(nombreArchivo, json);
        }
    }
}
