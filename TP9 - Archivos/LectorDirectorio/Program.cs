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
    Console.WriteLine(info.Name + " - " + info.Length / 1024 + " KB");
}

string csv = path + @"\reporte_archivos.csv";

if (!File.Exists(csv))
{
    File.Create(csv);
}

FileInfo[] infoArchivos = new DirectoryInfo(path).GetFiles();

using (StreamWriter sw = new(csv))
{
    foreach (var info in infoArchivos)
    {
        sw.WriteLine(info.Name + "," + info.Length / 1024 + "," + info.LastWriteTime);
    }
}