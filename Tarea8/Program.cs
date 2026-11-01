using System;
using System.Collections.Generic;

// CLASE BASE
class Vehiculo
{
    protected string placa;

    public Vehiculo(string placa)
    {
        this.placa = placa;
    }

    public virtual string Tipo()
    {
        return "Vehiculo";
    }

    public virtual int CalcularPeaje()
    {
        return 10;
    }

    public void Mostrar()
    {
        Console.WriteLine(Tipo() + " " + placa + ": " + CalcularPeaje() + " Bs");
    }
}

// CLASE HIJA: AUTO
class Auto : Vehiculo
{
    public Auto(string placa) : base(placa)
    {
    }

    public override string Tipo()
    {
        return "Auto";
    }
}

// CLASE HIJA: MOTO
class Moto : Vehiculo
{
    public Moto(string placa) : base(placa)
    {
    }

    public override string Tipo()
    {
        return "Moto";
    }

    public override int CalcularPeaje()
    {
        return 5;
    }
}

// CLASE HIJA: CAMION
class Camion : Vehiculo
{
    private int ejes;

    public Camion(string placa, int ejes) : base(placa)
    {
        this.ejes = ejes;
    }

    public override string Tipo()
    {
        return "Camion";
    }

    public override int CalcularPeaje()
    {
        return 10 + (8 * ejes);
    }
}

class Program
{
    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== TAREA 8: HERENCIA Y POLIMORFISMO =====");
            Console.WriteLine("1. Peaje de vehiculos");
            Console.WriteLine("2. Cuenta de ahorro y cuenta corriente");
            Console.WriteLine("3. Mi propia jerarquia");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1:
                    Ejercicio1();
                    break;

                case 2:
                    Ejercicio2();
                    break;

                case 3:
                    Ejercicio3();
                    break;

                case 0:
                    Console.WriteLine("Hasta luego.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 0);
    }

    // EJERCICIO 1: PEAJE DE VEHICULOS
    static void Ejercicio1()
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();

        Console.Write("\nCuantos vehiculos pasaron? ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Ingrese una cantidad valida.");
            return;
        }

        for (int i = 0; i < cantidad; i = i + 1)
        {
            Console.WriteLine("\nVehiculo " + (i + 1));
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Moto");
            Console.WriteLine("3. Camion");
            Console.Write("Seleccione el tipo: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo)
                || tipo < 1 || tipo > 3)
            {
                Console.WriteLine("Tipo no valido. Intente nuevamente.");
                i = i - 1;
                continue;
            }

            Console.Write("Ingrese la placa: ");
            string placa = Console.ReadLine() ?? "";

            if (tipo == 1)
            {
                vehiculos.Add(new Auto(placa));
            }
            else if (tipo == 2)
            {
                vehiculos.Add(new Moto(placa));
            }
            else if (tipo == 3)
            {
                Console.Write("Ingrese la cantidad de ejes: ");

                if (!int.TryParse(Console.ReadLine(), out int ejes) || ejes <= 0)
                {
                    Console.WriteLine("Cantidad de ejes no valida.");
                    i = i - 1;
                    continue;
                }

                vehiculos.Add(new Camion(placa, ejes));
            }
        }

        int total = 0;

        Console.WriteLine("\n--- Vehiculos registrados ---");

        foreach (Vehiculo vehiculo in vehiculos)
        {
            vehiculo.Mostrar();
            total = total + vehiculo.CalcularPeaje();
        }

        Console.WriteLine("Total recaudado: " + total + " Bs");
    }

    // EJERCICIO 2: CUENTAS
    static void Ejercicio2()
    {
        Console.WriteLine("\nEjercicio 2 pendiente.");
    }

    // EJERCICIO 3: JERARQUIA PROPIA
    static void Ejercicio3()
    {
        Console.WriteLine("\nEjercicio 3 pendiente.");
    }
}