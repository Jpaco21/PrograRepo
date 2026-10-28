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
            return titulo + " - Disponible";

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

class Producto
{
    private string nombre;
    private decimal precio;
    private int stock;

    public Producto(string nombre, decimal precio, int stock)
    {
        this.nombre = nombre;
        Precio = precio;
        this.stock = stock;
    }

    public decimal Precio
    {
        get { return precio; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    "value", "El precio no puede ser negativo.");

            precio = value;
        }
    }

    public void Vender(int cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad debe ser mayor que cero.");
        }
        else if (cantidad > stock)
        {
            Console.WriteLine("No hay suficiente stock.");
        }
        else
        {
            stock = stock - cantidad;
            Console.WriteLine("Venta realizada: " + nombre);
        }
    }

    public void Reponer(int cantidad)
    {
        if (cantidad > 0)
        {
            stock = stock + cantidad;
            Console.WriteLine("Stock actualizado: " + nombre);
        }
        else
        {
            Console.WriteLine("La cantidad debe ser mayor que cero.");
        }
    }

    public string ALinea()
    {
        return nombre + ";" + precio + ";" + stock;
    }

    public void Mostrar()
    {
        Console.WriteLine(
            "Producto: " + nombre +
            " | Precio: " + precio +
            " | Stock: " + stock);
    }
}

class Program
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 5)
        {
            Console.WriteLine("\n===== TAREA 7 =====");
            Console.WriteLine("1. Ejercicio 1: Cuenta bancaria");
            Console.WriteLine("2. Ejercicio 2: Biblioteca");
            Console.WriteLine("3. Ejercicio 3: Contactos");
            Console.WriteLine("4. Ejercicio 4: Productos");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                opcion = 0;
                continue;
            }

            if (opcion == 1)
                Ejercicio1();
            else if (opcion == 2)
                Ejercicio2();
            else if (opcion == 3)
                Ejercicio3();
            else if (opcion == 4)
                Ejercicio4();
            else if (opcion != 5)
                Console.WriteLine("Opcion no valida.");
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
                cuenta.MostrarResumen();
            else if (opcion != 4)
                Console.WriteLine("Opcion no valida.");
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
                string tituloLibro =
                    libros[j].MostrarEstado().Split('-')[0].Trim();

                if (tituloBuscado.Equals(
                    tituloLibro, StringComparison.OrdinalIgnoreCase))
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

        if (!int.TryParse(Console.ReadLine(), out int cantidad)
            || cantidad <= 0)
        {
            Console.WriteLine("Ingrese una cantidad valida.");
            return;
        }

        string[] lineas = new string[cantidad];

        for (int i = 0; i < cantidad; i = i + 1)
        {
            Console.WriteLine("\nContacto " + (i + 1));
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Telefono: ");
            string telefono = Console.ReadLine() ?? "";

            Contacto contacto = new Contacto(nombre, telefono);
            lineas[i] = contacto.ALinea();
        }

        File.WriteAllLines("contactos.txt", lineas);

        Console.WriteLine("\nContactos guardados en contactos.txt.");
        Console.WriteLine("\n--- Contactos leidos del archivo ---");

        string[] guardados = File.ReadAllLines("contactos.txt");

        foreach (string linea in guardados)
        {
            string[] datos = linea.Split(';');

            if (datos.Length == 2)
            {
                Contacto contacto = new Contacto(datos[0], datos[1]);
                contacto.Mostrar();
            }
        }
    }

    static void Ejercicio4()
    {
        Producto[] productos = new Producto[3];

        productos[0] = new Producto("Cuaderno", 15, 10);
        productos[1] = new Producto("Lapiz", 3, 20);
        productos[2] = new Producto("Mochila", 120, 5);

        Console.WriteLine("\n--- Productos iniciales ---");

        for (int i = 0; i < productos.Length; i = i + 1)
            productos[i].Mostrar();

        Console.WriteLine("\n--- Pruebas de productos ---");

        // Prueba 1: vender una cantidad valida.
        productos[0].Vender(2);

        // Prueba 2: reponer stock.
        productos[1].Reponer(5);

        // Prueba 3: intentar asignar un precio negativo.
        try
        {
            productos[2].Precio = -10;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Prueba correcta: no se acepta un precio negativo.");
        }

        string[] lineas = new string[productos.Length];

        for (int i = 0; i < productos.Length; i = i + 1)
            lineas[i] = productos[i].ALinea();

        File.WriteAllLines("productos.txt", lineas);

        Console.WriteLine("\nProductos guardados en productos.txt.");
        Console.WriteLine("\n--- Productos leidos del archivo ---");

        string[] guardados = File.ReadAllLines("productos.txt");

        foreach (string linea in guardados)
        {
            string[] datos = linea.Split(';');

            if (datos.Length == 3
                && decimal.TryParse(datos[1], out decimal precio)
                && int.TryParse(datos[2], out int stock))
            {
                Producto producto = new Producto(datos[0], precio, stock);
                producto.Mostrar();
            }
        }
    }
}