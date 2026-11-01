using System;
using System.Collections.Generic;

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
        Console.WriteLine(Tipo() + " " + placa +
            ": " + CalcularPeaje() + " Bs");
    }
}

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

class Cuenta
{
    protected string titular;
    protected int saldo;

    public Cuenta(string titular, int saldo)
    {
        this.titular = titular;
        this.saldo = saldo;
    }

    public virtual bool Retirar(int monto)
    {
        if (monto > 0 && saldo >= monto)
        {
            saldo = saldo - monto;
            return true;
        }

        return false;
    }

    public void IntentarRetiro(int monto)
    {
        bool aprobado = Retirar(monto);

        if (aprobado)
        {
            Console.WriteLine(titular + ": retiro de " +
                monto + " Bs aprobado. Saldo: " + saldo + " Bs");
        }
        else
        {
            Console.WriteLine(titular + ": retiro de " +
                monto + " Bs rechazado. Saldo: " + saldo + " Bs");
        }
    }
}

class CuentaCorriente : Cuenta
{
    private int limiteSobregiro = 500;

    public CuentaCorriente(string titular, int saldo)
        : base(titular, saldo)
    {
    }

    public override bool Retirar(int monto)
    {
        if (monto > 0 && saldo - monto >= -limiteSobregiro)
        {
            saldo = saldo - monto;
            return true;
        }

        return false;
    }
}

class EmpleadoRestaurante
{
    protected string nombre;
    protected int sueldoBase;

    public EmpleadoRestaurante(string nombre, int sueldoBase)
    {
        this.nombre = nombre;
        this.sueldoBase = sueldoBase;
    }

    public virtual string Tipo()
    {
        return "Empleado";
    }

    public virtual int CalcularPago()
    {
        return sueldoBase;
    }

    public void Mostrar()
    {
        Console.WriteLine(Tipo() + ": " + nombre +
            " - Pago: " + CalcularPago() + " Bs");
    }
}

class Cocinero : EmpleadoRestaurante
{
    private int platosPreparados;

    public Cocinero(string nombre, int sueldoBase, int platosPreparados)
        : base(nombre, sueldoBase)
    {
        this.platosPreparados = platosPreparados;
    }

    public override string Tipo()
    {
        return "Cocinero";
    }

    public override int CalcularPago()
    {
        return sueldoBase + (platosPreparados * 2);
    }
}

class Mesero : EmpleadoRestaurante
{
    private int mesasAtendidas;

    public Mesero(string nombre, int sueldoBase, int mesasAtendidas)
        : base(nombre, sueldoBase)
    {
        this.mesasAtendidas = mesasAtendidas;
    }

    public override string Tipo()
    {
        return "Mesero";
    }

    public override int CalcularPago()
    {
        return sueldoBase + (mesasAtendidas * 5);
    }
}

class Program
{
    static void Main()
    {
        int opcion = -1;

        do
        {
            Console.WriteLine("\n===== MENU PRINCIPAL =====");
            Console.WriteLine("1. Peaje de vehiculos");
            Console.WriteLine("2. Cuentas de ahorro y corriente");
            Console.WriteLine("3. Jerarquia de empleados");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                opcion = -1;
                continue;
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
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void Ejercicio1()
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();

        Console.Write("\nIngrese la cantidad de vehiculos: ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad)
            || cantidad <= 0)
        {
            Console.WriteLine("Cantidad no valida.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("\nVehiculo " + (i + 1));
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Moto");
            Console.WriteLine("3. Camion");
            Console.Write("Seleccione el tipo: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo)
                || tipo < 1 || tipo > 3)
            {
                Console.WriteLine("Tipo no valido.");
                i--;
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
            else
            {
                Console.Write("Ingrese la cantidad de ejes: ");

                if (!int.TryParse(Console.ReadLine(), out int ejes)
                    || ejes <= 0)
                {
                    Console.WriteLine("Cantidad de ejes no valida.");
                    i--;
                    continue;
                }

                vehiculos.Add(new Camion(placa, ejes));
            }
        }

        Console.WriteLine("\n--- PEAJES ---");

        int total = 0;

        foreach (Vehiculo vehiculo in vehiculos)
        {
            vehiculo.Mostrar();
            total += vehiculo.CalcularPeaje();
        }

        Console.WriteLine("Total recaudado: " + total + " Bs");
    }

    static void Ejercicio2()
    {
        Console.Write("\nIngrese el saldo inicial: ");

        if (!int.TryParse(Console.ReadLine(), out int saldoInicial)
            || saldoInicial < 0)
        {
            Console.WriteLine("Ingrese un saldo valido.");
            return;
        }

        Console.Write("Ingrese el monto que desea retirar: ");

        if (!int.TryParse(Console.ReadLine(), out int monto))
        {
            Console.WriteLine("Ingrese un monto valido.");
            return;
        }

        Cuenta ahorro = new Cuenta("Ahorro", saldoInicial);
        Cuenta corriente = new CuentaCorriente("Corriente", saldoInicial);

        Console.WriteLine("\n--- RESULTADO DE LOS RETIROS ---");

        ahorro.IntentarRetiro(monto);
        corriente.IntentarRetiro(monto);
    }

    static void Ejercicio3()
    {
        List<EmpleadoRestaurante> empleados =
            new List<EmpleadoRestaurante>();

        Console.Write("\nIngrese la cantidad de empleados: ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad)
            || cantidad <= 0)
        {
            Console.WriteLine("Ingrese una cantidad valida.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("\nEmpleado " + (i + 1));
            Console.WriteLine("1. Cocinero");
            Console.WriteLine("2. Mesero");
            Console.Write("Seleccione el tipo: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo)
                || (tipo != 1 && tipo != 2))
            {
                Console.WriteLine("Tipo no valido.");
                i--;
                continue;
            }

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Ingrese el sueldo base: ");

            if (!int.TryParse(Console.ReadLine(), out int sueldo)
                || sueldo < 0)
            {
                Console.WriteLine("Sueldo no valido.");
                i--;
                continue;
            }

            if (tipo == 1)
            {
                Console.Write("Ingrese los platos preparados: ");

                if (!int.TryParse(Console.ReadLine(), out int platos)
                    || platos < 0)
                {
                    Console.WriteLine("Cantidad no valida.");
                    i--;
                    continue;
                }

                empleados.Add(
                    new Cocinero(nombre, sueldo, platos));
            }
            else
            {
                Console.Write("Ingrese las mesas atendidas: ");

                if (!int.TryParse(Console.ReadLine(), out int mesas)
                    || mesas < 0)
                {
                    Console.WriteLine("Cantidad no valida.");
                    i--;
                    continue;
                }

                empleados.Add(
                    new Mesero(nombre, sueldo, mesas));
            }
        }

        Console.WriteLine("\n--- PAGOS DE EMPLEADOS ---");

        int total = 0;

        foreach (EmpleadoRestaurante empleado in empleados)
        {
            empleado.Mostrar();
            total += empleado.CalcularPago();
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine("Total de pagos: " + total + " Bs");
    }
}