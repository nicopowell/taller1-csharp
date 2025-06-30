using System.Text.Json.Serialization;

namespace ProductoSpace
{
    class Producto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("precio")]
        public int Precio { get; set; }
        [JsonPropertyName("porcentajeDeDescuento")]
        public double PorcentajeDeDescuento { get; set; }
        [JsonPropertyName("rating")]
        public double Rating { get; set; }
        [JsonPropertyName("stock")]
        public int Stock { get; set; }
        [JsonPropertyName("marca")]
        public string Marca { get; set; }
        [JsonPropertyName("categoria")]
        public string Categoria { get; set; }

        public double PrecioConDescuento()
        {
            return this.Precio - this.Precio * this.PorcentajeDeDescuento / 100.0;
        }
    }
}
