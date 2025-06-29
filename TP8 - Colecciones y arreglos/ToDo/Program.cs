// See https://aka.ms/new-console-template for more information
using Tareas;

void mostrarTareas(List<Tarea> tareas, string titulo)
{
    Console.WriteLine($"\n====== {titulo} ======");
    foreach (var tarea in tareas)
    {
        Console.WriteLine("\tID: " + tarea.TareaID);
        Console.WriteLine("\tDescripcion: " + tarea.Descripcion);
        Console.WriteLine("\tDuracion: " + tarea.Duracion);
        Console.WriteLine("");
    }
}

void moverTarea(List<Tarea> tareasBase, List<Tarea> tareasDestino)
{
    Console.Write("\tIngrese el ID de la tarea a mover: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Tarea tareaEncontrada = tareasBase.Find(tarea => tarea.TareaID == id);
        if (tareaEncontrada != null)
        {
            tareasBase.Remove(tareaEncontrada);
            tareasDestino.Add(tareaEncontrada);
        }
    }
}

void buscarTareas(List<Tarea> tareas)
{
    Console.Write("\tIngrese el termino para buscar en las tareas: ");
    string termino = Console.ReadLine();

    mostrarTareas(tareas.FindAll(tarea => tarea.Descripcion.ToLower().Contains(termino.ToLower())), "Tareas encontradas");
}

void mostrarMenu()
{
    Console.WriteLine("\n-----======= To Do =======-----");
    Console.WriteLine("\t1. Mostrar tareas pendientes");
    Console.WriteLine("\t2. Mostrar tareas realizadas");
    Console.WriteLine("\t3. Mover tarea a realizada");
    Console.WriteLine("\t4. Buscar tarea pendiente");
    Console.WriteLine("\t5. Salir");
}

Random rand = new();
string[] descripciones = ["Terminar TP Taller", "Estudiar Discreta", "Terminar TP arquitectura", "Ir al gym", "Terminar proyecto", "Practicar C#", "Cocinar", "Leer un libro"];

List<Tarea> tareasPendientes = [];
List<Tarea> tareasRealizadas = [];

int n = 0, opcion = 0;

while (n <= 0)
{
    Console.Write("Ingrese la cantidad de tareas a agregar: ");
    int.TryParse(Console.ReadLine(), out n);
}

// Cargo aleatoriamente las tareas pendientes
for (int i = 0; i < n; i++)
{
    Tarea nuevaTarea = new()
    {
        TareaID = i + 1,
        Descripcion = descripciones[rand.Next(0, descripciones.Length - 1)],
        Duracion = rand.Next(10, 100)
    };
    tareasPendientes.Add(nuevaTarea);
}

while (opcion != 5)
{
    mostrarMenu();
    Console.Write("\n\tSeleccione una opcion: ");
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                mostrarTareas(tareasPendientes, "Tareas pendientes");
                break;
            case 2:
                mostrarTareas(tareasRealizadas, "Tareas realizadas");
                break;
            case 3:
                moverTarea(tareasPendientes, tareasRealizadas);
                break;
            case 4:
                buscarTareas(tareasPendientes);
                break;
        }
    }
}