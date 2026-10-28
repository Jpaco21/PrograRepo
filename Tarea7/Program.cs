using System;

class CuentaBancaria
{
    private string titular;
    private decimal saldo;

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public decimal Saldo
    {
        get { return saldo; }
    }

    public void Depositar(decimal monto)
    {
        if (monto > 0)
        {
            saldo = saldo + monto;
            Console.WriteLine("Deposito realizado correctamente.");
        }
        else
        {
            Console.WriteLine("El monto debe ser mayor que cero.");
        }
    }

    public void Retirar(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto debe ser mayor que cero.");
        }
        else if (monto > saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else
        {
            saldo = saldo - monto;
            Console.WriteLine("Retiro realizado correctamente.");
        }
    }

    public void MostrarResumen()
    {
        Console.WriteLine("\n--- Resumen de la cuenta ---");
        Console.WriteLine("Titular: " + titular);
        Console.WriteLine("Saldo actual: " + saldo);
    }
}

class Program
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 2)
        {
            Console.WriteLine("\n===== TAREA 7 =====");
            Console.WriteLine("1. Ejercicio 1: Cuenta bancaria");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                opcion = 0;
                continue;
            }

            if (opcion == 1)
            {
                Ejercicio1();
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Programa finalizado.");
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
            }
        }
    }

    static void Ejercicio1()
    {
        Console.Write("Ingrese el nombre del titular: ");
        string titular = Console.ReadLine() ?? "";

        Console.Write("Ingrese el saldo inicial: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal saldoInicial)
            || saldoInicial < 0)
        {
            Console.WriteLine("El saldo inicial no puede ser negativo.");
            return;
        }

        CuentaBancaria cuenta = new CuentaBancaria(titular, saldoInicial);

        int opcion = 0;

        while (opcion != 4)
        {
            Console.WriteLine("\n--- Cuenta bancaria ---");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Mostrar resumen");
            Console.WriteLine("4. Volver al menu principal");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                opcion = 0;
                continue;
            }

            if (opcion == 1)
            {
                Console.Write("Monto a depositar: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal monto))
                {
                    cuenta.Depositar(monto);
                }
                else
                {
                    Console.WriteLine("Ingrese un monto valido.");
                }
            }
            else if (opcion == 2)
            {
                Console.Write("Monto a retirar: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal monto))
                {
                    cuenta.Retirar(monto);
                }
                else
                {
                    Console.WriteLine("Ingrese un monto valido.");
                }
            }
            else if (opcion == 3)
            {
                cuenta.MostrarResumen();
            }
            else if (opcion != 4)
            {
                Console.WriteLine("Opcion no valida.");
            }
        }
    }
}