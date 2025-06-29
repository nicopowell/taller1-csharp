using System.Text.Json;
using UniversidadState;

var universidades = await ObtenerUniversidadesAsync();

Console.WriteLine("=== Universidades Argentinas ===");
foreach (var universidad in universidades)
{
    Console.WriteLine($"Nombre: {universidad.Name}");
    Console.WriteLine($"Provincia: {universidad.StateProvince}");
    Console.WriteLine($"Pagina web: {string.Join(", ", universidad.WebPages)}");
    Console.WriteLine($"Dominios: {string.Join(", ", universidad.Domains)}");
    Console.WriteLine();
}

GuardarUsuariosEnArchivo(universidades);
Console.WriteLine("Universidades guardados en el archivo universidades.json");

static async Task<List<Universidad>> ObtenerUniversidadesAsync()
{
    HttpClient client = new();
    var url = "http://universities.hipolabs.com/search?country=Argentina";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    return JsonSerializer.Deserialize<List<Universidad>>(responseBody);
}

static void GuardarUsuariosEnArchivo(List<Universidad> universidades)
{
    string json = JsonSerializer.Serialize(universidades);
    File.WriteAllText("universidades.json", json);
}