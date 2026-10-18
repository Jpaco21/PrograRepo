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
            Console.WriteLine("0. Salir");

            opcion = Validador.LeerEntero("Elige una opcion: ", 0, 1);

            if (opcion == 1)
            {
                Ejercicio1();
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
            int nota = Validador.LeerEntero("Nota del estudiante " + i + " (0 a 100): ", 0, 100);

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
}
