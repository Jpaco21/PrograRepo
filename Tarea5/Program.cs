using System;
using System.Collections.Generic;

static class Validador
{
    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            int numero;

            if (int.TryParse(texto, out numero) && numero >= min && numero <= max)
                return numero;

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
                return texto.Trim();

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
                    return true;

                if (respuesta == "n")
                    return false;
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
            Console.WriteLine("3. Calculadora con historial");
            Console.WriteLine("4. Cola de cafeteria");
            Console.WriteLine("0. Salir");

            opcion = Validador.LeerEntero("Elige una opcion: ", 0, 4);

            if (opcion == 1)
                Ejercicio1();
            else if (opcion == 2)
                Ejercicio2();
            else if (opcion == 3)
                Ejercicio3();
            else if (opcion == 4)
                Ejercicio4();

        } while (opcion != 0);
    }

    static void Ejercicio1()
    {
        int cantidad = Validador.LeerEntero("Cantidad de notas (1 a 10): ", 1, 10);
        int suma = 0;
        int aprobados = 0;
        int mayor = -1;

        for (int i = 1; i <= cantidad; i = i + 1)
        {
            int nota = Validador.LeerEntero("Nota " + i + " (0 a 100): ", 0, 100);
            suma = suma + nota;

            if (nota >= 51)
                aprobados = aprobados + 1;

            if (nota > mayor)
                mayor = nota;
        }

        Console.WriteLine("Suma de notas: " + suma);
        Console.WriteLine("Aprobados: " + aprobados + " de " + cantidad);
        Console.WriteLine("Nota mayor: " + mayor);
    }

    static void Ejercicio2()
    {
        decimal total = 0;
        bool continuar;

        do
        {
            string nombre = Validador.LeerTexto("Nombre del producto: ");
            int precio = Validador.LeerEntero("Precio (1 a 1000 Bs): ", 1, 1000);
            int cantidad = Validador.LeerEntero("Cantidad (1 a 50): ", 1, 50);

            decimal subtotal = precio * cantidad;
            total = total + subtotal;

            Console.WriteLine("Subtotal de " + nombre + ": " + subtotal + " Bs");

            continuar = Validador.LeerSiNo("Agregar otro producto? (s/n): ");

        } while (continuar);

        Console.WriteLine("Total de la compra: " + total + " Bs");
    }

    static void Ejercicio3()
    {
        Stack<int> resultados = new Stack<int>();
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== CALCULADORA CON HISTORIAL =====");
            Console.WriteLine("1. Sumar dos numeros");
            Console.WriteLine("2. Ver ultimo resultado");
            Console.WriteLine("3. Borrar ultimo resultado");
            Console.WriteLine("4. Salir");

            opcion = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            if (opcion == 1)
            {
                int a = Validador.LeerEntero("Primer numero (-1000 a 1000): ", -1000, 1000);
                int b = Validador.LeerEntero("Segundo numero (-1000 a 1000): ", -1000, 1000);
                int resultado = a + b;

                Console.WriteLine(a + " + " + b + " = " + resultado);
                resultados.Push(resultado);
            }
            else if (opcion == 2)
            {
                if (resultados.Count > 0)
                    Console.WriteLine("Ultimo resultado: " + resultados.Peek());
                else
                    Console.WriteLine("No hay resultados");
            }
            else if (opcion == 3)
            {
                if (resultados.Count > 0)
                    Console.WriteLine("Se borro: " + resultados.Pop());
                else
                    Console.WriteLine("No hay resultados para borrar");
            }

        } while (opcion != 4);

        Console.WriteLine("Resultados guardados: " + resultados.Count);
    }

    static void Ejercicio4()
    {
        Queue<string> fila = new Queue<string>();
        int fichas = 0;
        int atendidos = 0;
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== CAFETERIA =====");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Atender siguiente cliente");
            Console.WriteLine("3. Ver personas en la fila");
            Console.WriteLine("4. Mostrar atendidos y salir");

            opcion = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            if (opcion == 1)
            {
                string nombre = Validador.LeerTexto("Nombre del cliente: ");

                fichas = fichas + 1;
                fila.Enqueue(nombre);

                Console.WriteLine("Ficha " + fichas + " para " + nombre);
            }
            else if (opcion == 2)
            {
                if (fila.Count > 0)
                {
                    string nombre = fila.Dequeue();
                    atendidos = atendidos + 1;

                    Console.WriteLine("Atendiendo a " + nombre);
                }
                else
                {
                    Console.WriteLine("No hay nadie en la fila");
                }
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Personas en la fila: " + fila.Count);
            }
            else if (opcion == 4)
            {
                Console.WriteLine("Atendidos hoy: " + atendidos);
            }

        } while (opcion != 4);
    }
}