using System.Text.Json;
using UsuarioSpace;

var usuarios = await ObtenerUsuariosAsync();

Console.WriteLine("=== PRIMEROS 5 USUARIOS ===");
foreach (var usuario in usuarios.Take(5))
{
    string domicilio;
    if (usuario.Address != null)
    {
        domicilio = $"{usuario.Address.Street}, {usuario.Address.Suite}, {usuario.Address.City} ({usuario.Address.Zipcode})";
    }
    else
    {
        domicilio = "Domicilio no disponible";
    }
    Console.WriteLine($"Nombre: {usuario.Name}");
    Console.WriteLine($"Email: {usuario.Email}");
    Console.WriteLine($"Domicilio: {domicilio}");
    Console.WriteLine();
}

GuardarUsuariosEnArchivo(usuarios);
Console.WriteLine("Usuarios guardados en el archivo usuarios.json");

static async Task<List<Usuario>> ObtenerUsuariosAsync()
{
    HttpClient client = new();
    var url = "https://jsonplaceholder.typicode.com/users/";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    var opciones = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    return JsonSerializer.Deserialize<List<Usuario>>(responseBody, opciones);
}

void GuardarUsuariosEnArchivo(List<Usuario> usuarios)
{
    string json = JsonSerializer.Serialize(usuarios);
    File.WriteAllText("usuarios.json", json);
}