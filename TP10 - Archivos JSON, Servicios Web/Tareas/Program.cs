
using System.Text.Json;
using TareaSpace;



var tareas = await GetTareasAsync();

// Primero mostrar tareas pendientes
Console.WriteLine("=== TAREAS PENDIENTES ===");
foreach (var tarea in tareas.Where(t => !t.Completed))
{
    Console.WriteLine($"- {tarea.Title} (❌ Pendiente)");
}

// Luego mostrar tareas completadas
Console.WriteLine("\n=== TAREAS COMPLETADAS ===");
foreach (var tarea in tareas.Where(t => t.Completed))
{
    Console.WriteLine($"- {tarea.Title} (✔️  Completada)");
}

Console.WriteLine("\nGuardando tareas en tareas.json");
await GuardarTareas(tareas);

// Función para obtener tareas desde la API
async Task<List<Tarea>> GetTareasAsync()
{
    var url = "https://jsonplaceholder.typicode.com/todos/";

    try
    {
        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
        return tareas;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}

async Task GuardarTareas(List<Tarea> tareas)
{
    string jsonString = JsonSerializer.Serialize(tareas);
    await File.WriteAllTextAsync("tareas.json", jsonString);
}
