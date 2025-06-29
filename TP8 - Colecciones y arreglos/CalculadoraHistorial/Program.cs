using EspacioCalculadora;

void mostrarMenu()
{
    Console.WriteLine("\n====== CALCULADORA ======");
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Limpiar");
    Console.WriteLine("6. Mostrar historial");
    Console.WriteLine("7. Salir");
}

double ingresarTermino()
{
    double termino;
    do
    {
        Console.Write("Ingrese un numero: ");
    } while (!double.TryParse(Console.ReadLine(), out termino));
    return termino;
}

Calculadora calculadora = new Calculadora();

int opcion = 0;
double termino;

while (opcion != 7)
{
    mostrarMenu();

    Console.Write("Seleccione una opcion: ");
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                termino = ingresarTermino();
                Console.Write(calculadora.Resultado + " + " + termino + " = ");
                calculadora.Suma(termino);
                Console.WriteLine(calculadora.Resultado);
                break;
            case 2:
                termino = ingresarTermino();
                Console.Write(calculadora.Resultado + " - " + termino + " = ");
                calculadora.Resta(termino);
                Console.WriteLine(calculadora.Resultado);
                break;
            case 3:
                termino = ingresarTermino();
                Console.Write(calculadora.Resultado + " * " + termino + " = ");
                calculadora.Multiplicacion(termino);
                Console.WriteLine(calculadora.Resultado);
                break;
            case 4:
                termino = ingresarTermino();
                Console.Write(calculadora.Resultado + " / " + termino + " = ");
                calculadora.Division(termino);
                Console.WriteLine(calculadora.Resultado);
                break;
            case 5:
                Console.WriteLine("Limpiando memoria");
                calculadora.Limpiar();
                break;
            case 6:
                calculadora.MostrarHistorial();
                break;
        }
    }
}