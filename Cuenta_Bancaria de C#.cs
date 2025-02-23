using System;
// Autor: Alexander Guzman Vasquez //
// Fecha: 23-02-2025 //
// Descripción: Implementación de Cuenta Bancaria en C# //
class CuentaBancaria
{
    private string titular;
    private decimal saldo;

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public string Titular()
    {
        return titular;
    }

    public void Depositar(decimal monto)
    {
        Console.WriteLine($"\nTitular de la cuenta: {titular}");
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

    public void Retirar(decimal monto)
    {
        Console.WriteLine($"\nTitular de la cuenta: {titular}");
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
        CuentaBancaria cuenta1 = new CuentaBancaria("Penencio Rodriguez", 3000m);
        CuentaBancaria cuenta2 = new CuentaBancaria("Ana Perez", 5000m);
        CuentaBancaria cuenta3 = new CuentaBancaria("Carlos Gomez", 7000m);

        while (true)
        {
            Console.WriteLine("\nMenú de operaciones:");
            Console.WriteLine("1. Depositar dinero");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Mostrar información de las cuentas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
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
            if (!int.TryParse(Console.ReadLine(), out int numCuenta) || numCuenta < 1 || numCuenta > 3)
            {
                Console.WriteLine("Número de cuenta inválido.");
                continue;
            }

            CuentaBancaria cuentaSeleccionada = numCuenta == 1 ? cuenta1 : numCuenta == 2 ? cuenta2 : cuenta3;

            if (opcion == 1)
            {
                Console.Write($"Ingrese el monto a depositar en la cuenta de {cuentaSeleccionada.Titular()}: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal monto))
                {
                    Console.WriteLine("Monto inválido. Intente de nuevo.");
                    continue;
                }
                cuentaSeleccionada.Depositar(monto);
            }
            else if (opcion == 2)
            {
                Console.Write($"Ingrese el monto a retirar de la cuenta de {cuentaSeleccionada.Titular()}: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal monto))
                {
                    Console.WriteLine("Monto inválido. Intente de nuevo.");
                    continue;
                }
                cuentaSeleccionada.Retirar(monto);
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
