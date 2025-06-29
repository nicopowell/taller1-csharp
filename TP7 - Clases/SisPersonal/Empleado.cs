namespace EspacioEmpleado
{
    public enum Cargos
    {
        Auxiliar,
        Administrativo,
        Ingeniero,
        Especialista,
        Investigador
    }

    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public char EstadoCivil { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public double SueldoBasico { get; set; }
        public Cargos Cargo { get; set; }

        // Propiedades calculadas
        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - FechaDeNacimiento.Year;
                if (DateTime.Today < FechaDeNacimiento.AddYears(edad))
                    edad--;
                return edad;
            }
        }

        public int Antiguedad
        {
            get
            {
                int antig = DateTime.Today.Year - FechaDeIngreso.Year;
                if (DateTime.Today < FechaDeIngreso.AddYears(antig))
                    antig--;
                return antig;
            }
        }

        public int AniosHastaJubilarse()
        {
            return Math.Max(65 - Edad, 0);
        }

        public double Salario()
        {
            double adicional;

            if (Antiguedad <= 20)
                adicional = SueldoBasico * (Antiguedad * 0.01);
            else
                adicional = SueldoBasico * 0.25;

            if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
                adicional *= 1.5;

            if (EstadoCivil == 'C')
                adicional += 150000;

            return SueldoBasico + adicional;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Antigüedad: {Antiguedad} años");
            Console.WriteLine($"Años para jubilarse: {AniosHastaJubilarse()}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salario: ${Salario():N2}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
