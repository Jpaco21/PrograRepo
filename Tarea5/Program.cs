using System;

static class Validador
{
    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            int numero;

            if (int.TryParse(texto, out numero) &&
                numero >= min && numero <= max)
            {
                return numero;
            }

            Console.WriteLine("Dato invalido. Escribe un numero entre " + min + " y " + max);
        }
    }

    public static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }

            Console.WriteLine("El texto no puede estar vacio");
        }
    }

    public static bool LeerSiNo(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string respuesta = Console.ReadLine();

            if (respuesta != null)
            {
                respuesta = respuesta.Trim().ToLower();

                if (respuesta == "s")
                {
                    return true;
                }

                if (respuesta == "n")
                {
                    return false;
                }
            }

            Console.WriteLine("Responde solo s o n");
        }
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
            Console.WriteLine("===== TAREA 5 =====");
            Console.WriteLine("1. Registro de notas");
            Console.WriteLine("2. Carrito de compras");
            Console.WriteLine("0. Salir");

            opcion = Validador.LeerEntero("Elige una opcion: ", 0, 2);

            if (opcion == 1)
            {
                Ejercicio1();
            }
            else if (opcion == 2)
            {
                Ejercicio2();
            }

        } while (opcion != 0);
    }

    static void Ejercicio1()
    {
        int n = Validador.LeerEntero("Cantidad de estudiantes (1 a 10): ", 1, 10);
        int suma = 0;
        int aprobados = 0;
        int mayor = 0;

        for (int i = 1; i <= n; i = i + 1)
        {
            int nota = Validador.LeerEntero(
                "Nota del estudiante " + i + " (0 a 100): ", 0, 100);

            suma = suma + nota;

            if (nota >= 51)
            {
                aprobados = aprobados + 1;
            }

            if (i == 1 || nota > mayor)
            {
                mayor = nota;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Suma de notas: " + suma);
        Console.WriteLine("Aprobados: " + aprobados + " de " + n);
        Console.WriteLine("Nota mas alta: " + mayor);
    }

    static void Ejercicio2()
    {
        int total = 0;
        int productos = 0;
        bool otro;

        do
        {
            string nombre = Validador.LeerTexto("Nombre del producto: ");
            int precio = Validador.LeerEntero("Precio (1 a 1000 Bs): ", 1, 1000);
            int cantidad = Validador.LeerEntero("Cantidad (1 a 50): ", 1, 50);

            int subtotal = precio * cantidad;

            Console.WriteLine(nombre + ": " + cantidad + " x " + precio + " = " + subtotal + " Bs");

            total = total + subtotal;
            productos = productos + 1;

            otro = Validador.LeerSiNo("Agregar otro producto? (s/n): ");

        } while (otro);

        Console.WriteLine();
        Console.WriteLine("Productos distintos: " + productos);
        Console.WriteLine("Total a pagar: " + total + " Bs");
    }
}