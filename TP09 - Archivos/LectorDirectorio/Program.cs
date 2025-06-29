Console.Write("Ingrese un path para analizar: ");
string path = Console.ReadLine();

while (!Directory.Exists(path))
{
    Console.Write("El path no existe, ingrese otro: ");
    path = Console.ReadLine();
}

Console.WriteLine("\n=== Carpetas ===");
foreach (var carpeta in Directory.GetDirectories(path))
{
    var infoCarpeta = new DirectoryInfo(carpeta).Name;
    Console.WriteLine(infoCarpeta);
}

Console.WriteLine("\n=== Archivos ===");
foreach (var archivo in Directory.GetFiles(path))
{
    var info = new FileInfo(archivo);
    double sizeKb = Math.Round(info.Length / 1024.0, 2);
    Console.WriteLine($"{info.Name} - {sizeKb} KB");
}

string csv = Path.Combine(path, "reporte_archivos.csv");

// Si el archivo existe, no hay que crear con File.Create porque deja abierto el handle
// Solo abrimos para escritura con StreamWriter (sobrescribiendo)

FileInfo[] infoArchivos = new DirectoryInfo(path).GetFiles();

using (StreamWriter sw = new StreamWriter(csv))
{
    // Es buena práctica poner cabecera
    sw.WriteLine("Nombre del Archivo,Tamaño (KB),Fecha de Última Modificación");
    foreach (var info in infoArchivos)
    {
        double sizeKb = Math.Round(info.Length / 1024.0, 2);
        string fecha = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
        sw.WriteLine($"{info.Name},{sizeKb},{fecha}");
    }
}