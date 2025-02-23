using System;

class CuentaBancaria
{
    // Atributos privados
    private string titular;
    private decimal saldo;

    // Constructor
    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    // Método para depositar dinero
    public void Depositar(decimal monto)
    {
        if (monto > 0)
        {
            saldo += monto;
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: RD${saldo:N2}");
        }
        else
        {
            Console.WriteLine("El monto a depositar debe ser mayor a 0.");
        }
    }

    // Método para retirar dinero
    public void Retirar(decimal monto)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD${saldo:N2}");
        }
        else if (monto > saldo)
        {
            Console.WriteLine("Fondos insuficientes.");
        }
        else
        {
            Console.WriteLine("El monto a retirar debe ser mayor a 0.");
        }
    }

    // Método para mostrar información de la cuenta
    public void MostrarInformacion()
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine($"Titular: {titular}");
        Console.WriteLine($"Saldo: RD${saldo:N2}");
        Console.WriteLine("----------------------------------\n");
    }
}

class Program
{
    static void Main()
    {
        // Instanciando cuentas bancarias
        CuentaBancaria cuenta1 = new CuentaBancaria("Penencio Rodriguez", 3000m);
        CuentaBancaria cuenta2 = new CuentaBancaria("Ana Perez", 5000m);
        CuentaBancaria cuenta3 = new CuentaBancaria("Carlos Gomez", 7000m);

        // Menú de opciones
        while (true)
        {
            Console.WriteLine("\nMenú de operaciones:");
            Console.WriteLine("1. Depositar dinero");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Mostrar información de las cuentas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            if (opcion == 4)
            {
                Console.WriteLine("Gracias por usar el sistema.");
                break;
            }

            Console.Write("Ingrese el número de cuenta (1, 2 o 3): ");
            int numCuenta;
            if (!int.TryParse(Console.ReadLine(), out numCuenta) || numCuenta < 1 || numCuenta > 3)
            {
                Console.WriteLine("Número de cuenta inválido.");
                continue;
            }

            CuentaBancaria cuentaSeleccionada = numCuenta == 1 ? cuenta1 : numCuenta == 2 ? cuenta2 : cuenta3;

            if (opcion == 1)
            {
                Console.Write("Ingrese el monto a depositar: ");
                decimal monto;
                if (decimal.TryParse(Console.ReadLine(), out monto))
                {
                    cuentaSeleccionada.Depositar(monto);
                }
                else
                {
                    Console.WriteLine("Ingrese un monto válido.");
                }
            }
            else if (opcion == 2)
            {
                Console.Write("Ingrese el monto a retirar: ");
                decimal monto;
                if (decimal.TryParse(Console.ReadLine(), out monto))
                {
                    cuentaSeleccionada.Retirar(monto);
                }
                else
                {
                    Console.WriteLine("Ingrese un monto válido.");
                }
            }
            else if (opcion == 3)
            {
                cuenta1.MostrarInformacion();
                cuenta2.MostrarInformacion();
                cuenta3.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}