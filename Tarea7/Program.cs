using System;
using System.IO;

class CuentaBancaria
{
    private string titular;
    private decimal saldo;

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        saldo = saldoInicial;
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

class Libro
{
    private string titulo;
    private bool disponible;

    public Libro(string titulo)
    {
        this.titulo = titulo;
        disponible = true;
    }

    public bool Prestar()
    {
        if (disponible)
        {
            disponible = false;
            return true;
        }

        return false;
    }

    public string MostrarEstado()
    {
        if (disponible)
        {
            return titulo + " - Disponible";
        }

        return titulo + " - Prestado";
    }
}

class Contacto
{
    private string nombre;
    private string telefono;

    public Contacto(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public string ALinea()
    {
        return nombre + ";" + telefono;
    }

    public void Mostrar()
    {
        Console.WriteLine("Nombre: " + nombre + " | Telefono: " + telefono);
    }
}

class Program
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 4)
        {
            Console.WriteLine("\n===== TAREA 7 =====");
            Console.WriteLine("1. Ejercicio 1: Cuenta bancaria");
            Console.WriteLine("2. Ejercicio 2: Biblioteca");
            Console.WriteLine("3. Ejercicio 3: Contactos");
            Console.WriteLine("4. Salir");
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
                Ejercicio2();
            }
            else if (opcion == 3)
            {
                Ejercicio3();
            }
            else if (opcion != 4)
            {
                Console.WriteLine("Opcion no valida.");
            }
        }

        Console.WriteLine("Programa finalizado.");
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
                    cuenta.Depositar(monto);
                else
                    Console.WriteLine("Ingrese un monto valido.");
            }
            else if (opcion == 2)
            {
                Console.Write("Monto a retirar: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal monto))
                    cuenta.Retirar(monto);
                else
                    Console.WriteLine("Ingrese un monto valido.");
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

    static void Ejercicio2()
    {
        Libro[] libros = new Libro[3];

        libros[0] = new Libro("El Principito");
        libros[1] = new Libro("Don Quijote");
        libros[2] = new Libro("Rayuela");

        Console.WriteLine("\n--- Libros disponibles ---");

        for (int i = 0; i < libros.Length; i = i + 1)
            Console.WriteLine(libros[i].MostrarEstado());

        for (int i = 0; i < 2; i = i + 1)
        {
            Console.Write("\nIngrese el titulo del libro que desea prestar: ");
            string tituloBuscado = Console.ReadLine() ?? "";
            bool encontrado = false;

            for (int j = 0; j < libros.Length; j = j + 1)
            {
                string tituloLibro = libros[j].MostrarEstado().Split('-')[0].Trim();

                if (tituloBuscado.Equals(tituloLibro, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;

                    if (libros[j].Prestar())
                        Console.WriteLine("Libro prestado correctamente.");
                    else
                        Console.WriteLine("El libro ya esta prestado.");

                    break;
                }
            }

            if (!encontrado)
                Console.WriteLine("Libro no encontrado.");
        }

        Console.WriteLine("\n--- Estado final de los libros ---");

        for (int i = 0; i < libros.Length; i = i + 1)
            Console.WriteLine(libros[i].MostrarEstado());
    }

    static void Ejercicio3()
    {
        Console.Write("Cuantos contactos desea registrar? ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Ingrese una cantidad valida.");
            return;
        }

        Contacto[] contactos = new Contacto[cantidad];
        string[] lineas = new string[cantidad];

        for (int i = 0; i < cantidad; i = i + 1)
        {
            Console.WriteLine("\nContacto " + (i + 1));

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Telefono: ");
            string telefono = Console.ReadLine() ?? "";

            contactos[i] = new Contacto(nombre, telefono);
            lineas[i] = contactos[i].ALinea();
        }

        File.WriteAllLines("contactos.txt", lineas);

        Console.WriteLine("\nContactos guardados en contactos.txt.");
        Console.WriteLine("\n--- Contactos leidos del archivo ---");

        string[] contactosGuardados = File.ReadAllLines("contactos.txt");

        foreach (string linea in contactosGuardados)
        {
            string[] datos = linea.Split(';');

            if (datos.Length == 2)
            {
                Contacto contacto = new Contacto(datos[0], datos[1]);
                contacto.Mostrar();
            }
        }
    }
}