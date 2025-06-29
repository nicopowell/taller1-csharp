namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double resultado;

        private List<Operacion> operaciones;

        public double Resultado
        {
            get => resultado;
        }

        public void Suma(double termino)
        {
            operaciones.Add(new Operacion
            {
                Resultado = resultado,
                NuevoValor = termino,
                OperacionGetSet = TipoOperacion.Suma,
            });

            resultado += termino;
        }
        public void Resta(double termino)
        {
            operaciones.Add(new Operacion
            {
                Resultado = resultado,
                NuevoValor = termino,
                OperacionGetSet = TipoOperacion.Resta,
            });

            resultado -= termino;
        }
        public void Multiplicacion(double termino)
        {
            operaciones.Add(new Operacion
            {
                Resultado = resultado,
                NuevoValor = termino,
                OperacionGetSet = TipoOperacion.Multiplicacion,
            });

            resultado *= termino;
        }
        public void Division(double termino)
        {
            operaciones.Add(new Operacion
            {
                Resultado = resultado,
                NuevoValor = termino,
                OperacionGetSet = TipoOperacion.Division,
            });

            resultado /= termino;
        }
        public void Limpiar()
        {
            operaciones.Add(new Operacion
            {
                Resultado = resultado,
                NuevoValor = 0,
                OperacionGetSet = TipoOperacion.Limpiar,
            });

            resultado = 0;
        }

        public Calculadora()
        {
            resultado = 0;
            operaciones = [];
        }

        public void MostrarHistorial()
        {
            Console.WriteLine("\n==== HISTORIAL DE OPERACIONES ====");

            if (operaciones.Count == 0)
            {
                Console.WriteLine("No hay operaciones registradas.");
                return;
            }

            foreach (var op in operaciones)
            {
                string simbolo = op.OperacionGetSet switch
                {
                    TipoOperacion.Suma => "+",
                    TipoOperacion.Resta => "-",
                    TipoOperacion.Multiplicacion => "*",
                    TipoOperacion.Division => "/",
                    TipoOperacion.Limpiar => "LIMPIAR",
                    _ => "?",
                };
                if (op.OperacionGetSet == TipoOperacion.Limpiar)
                {
                    Console.WriteLine($"[ LIMPIAR ] Resultado antes de limpiar: {op.Resultado}");
                }
                else
                {
                    Console.WriteLine($"{op.Resultado} {simbolo} {op.NuevoValor} = {CalcularResultado(op)}");
                }
            }
        }

        private double CalcularResultado(Operacion op)
        {
            return op.OperacionGetSet switch
            {
                TipoOperacion.Suma => op.Resultado + op.NuevoValor,
                TipoOperacion.Resta => op.Resultado - op.NuevoValor,
                TipoOperacion.Multiplicacion => op.Resultado * op.NuevoValor,
                TipoOperacion.Division => op.Resultado / op.NuevoValor,
                _ => 0
            };
        }
    }

    public class Operacion
    {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;

        public double Resultado { get => resultadoAnterior; set => resultadoAnterior = value; }
        public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
        public TipoOperacion OperacionGetSet { get => operacion; set => operacion = value; }
    }

    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }
}