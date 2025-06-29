using EspacioEmpleado;

Empleado[] empleados = new Empleado[3];

        empleados[0] = new Empleado
        {
            Nombre = "Juan",
            Apellido = "Pérez",
            FechaDeNacimiento = new DateTime(1970, 5, 15),
            EstadoCivil = 'C',
            FechaDeIngreso = new DateTime(2005, 3, 1),
            SueldoBasico = 650000,
            Cargo = Cargos.Ingeniero
        };

        empleados[1] = new Empleado
        {
            Nombre = "Ana",
            Apellido = "Gómez",
            FechaDeNacimiento = new DateTime(1985, 8, 20),
            EstadoCivil = 'S',
            FechaDeIngreso = new DateTime(2010, 7, 1),
            SueldoBasico = 580000,
            Cargo = Cargos.Administrativo
        };

        empleados[2] = new Empleado
        {
            Nombre = "Luis",
            Apellido = "Martínez",
            FechaDeNacimiento = new DateTime(1990, 1, 10),
            EstadoCivil = 'C',
            FechaDeIngreso = new DateTime(2020, 1, 1),
            SueldoBasico = 700000,
            Cargo = Cargos.Especialista
        };

        // Mostrar los datos de todos
        Console.WriteLine("== Empleados Registrados ==\n");
        foreach (var emp in empleados)
        {
            emp.MostrarDatos();
        }

        // Monto total de salarios
        double totalSalarios = 0;
        foreach (var emp in empleados)
        {
            totalSalarios += emp.Salario();
        }

        Console.WriteLine($"\nMonto total en concepto de salarios: ${totalSalarios:N2}\n");

        // Empleado más próximo a jubilarse
        Empleado proximoAJubilarse = empleados[0];
        foreach (var emp in empleados)
        {
            if (emp.AniosHastaJubilarse() < proximoAJubilarse.AniosHastaJubilarse())
            {
                proximoAJubilarse = emp;
            }
        }

        Console.WriteLine("== Empleado más próximo a jubilarse ==\n");
        proximoAJubilarse.MostrarDatos();