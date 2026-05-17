using System;
using System.IO; // Para poder usar archivos txt
class Program
{
    // Guarda los nombres de los pasajeros
    static string[] nombres = new string[10];

    // Guarda los números de asiento
    static string[] asientos = new string[10];

    // Guarda las comidas reservadas
    static string[] reservas = new string[10];

    // Guarda el precio de cada reserva
    static double[] preciosReserva = new double[10];

    // Guardar el registro de reservas
    static string archivo = "reservas.txt";

    // MENÚ DE COMIDAS
    static string[] comidas =
    {
        "Pollo",
        "Carne",
        "Vegetariano",
        "Pasta",
        "Ensalada"
    };

    // Precios correspondientes a cada comida
    static double[] precios =
    {
        8.50,
        10.00,
        7.25,
        9.50,
        6.75
    };

    // VARIABLES GENERALES

    // Lleva el control de reservas realizadas
    static int contador = 0;

    // Guarda el total acumulado de todas las reservas
    static double totalGeneral = 0;

    // MÉTODO PRINCIPAL
    static void Main()
    {
        // Cambia el título de la consola
        Console.Title = "Sistema de Reserva de Comida";

        // Carga las reservas
        CargarReservasArchivo();

        // Llama al menú principal
        MostrarMenuPrincipal();
    }

    // MENÚ PRINCIPAL
    static void MostrarMenuPrincipal()
    {
        int opcion = 0;

        // El menú se repetirá hasta que el usuario elija salir
        while (opcion != 5)
        {
            Console.Clear();

            Console.WriteLine("=== SISTEMA DE RESERVAS ===");
            Console.WriteLine("1. Ver menú de comidas");
            Console.WriteLine("2. Realizar reserva");
            Console.WriteLine("3. Ver reservas");
            Console.WriteLine("4. Cancelar reserva");
            Console.WriteLine("5. Salir");

            Console.Write("\nSeleccione una opción: ");

            // Validar que el usuario ingrese números
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe ingresar un número válido.");
                Console.ReadKey();
                continue;
            }

            // Evaluar la opción seleccionada
            switch (opcion)
            {
                case 1:
                    MostrarComidas();
                    break;

                case 2:
                    CrearReserva();
                    break;

                case 3:
                    MostrarReservas();
                    break;

                case 4:
                    CancelarReserva();
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    // MOSTRAR MENÚ DE COMIDAS
    static void MostrarComidas()
    {
        Console.WriteLine("\n--- MENÚ DE COMIDAS ---");

        // Recorrer todas las comidas disponibles
        for (int i = 0; i < comidas.Length; i++)
        {
            Console.WriteLine(
                (i + 1) + ". " +
                comidas[i] +
                " - $" +
                precios[i]
            );
        }
    }

    // CREAR RESERVA
    static void CrearReserva()
    {
        // Verificar límite total de reservas
        if (contador >= 10)
        {
            Console.WriteLine("No hay espacio para más reservas.");
            return;
        }

        // Solicitar nombre del pasajero
        Console.Write("\nIngrese nombre del pasajero: ");
        string nombre = Console.ReadLine();

        // Validar que el nombre no esté vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        // Solicitar número de asiento
        Console.Write("Ingrese número de asiento: ");
        string asiento = Console.ReadLine();

        // Validar asiento vacío
        if (string.IsNullOrWhiteSpace(asiento))
        {
            Console.WriteLine("El asiento no puede estar vacío.");
            return;
        }

        // Verificar cuántas reservas tiene ese asiento
        int cantidadReservas = ContarReservasAsiento(asiento);

        // Limitar reservas por asiento
        if (cantidadReservas >= 2)
        {
            Console.WriteLine("Este asiento ya alcanzó el límite de reservas.");
            return;
        }

        // Mostrar comidas disponibles
        MostrarComidas();

        Console.Write("\nSeleccione una comida: ");

        int opcion;

        // Validar que se ingrese un número
        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Debe ingresar un número válido.");
            return;
        }

        // Verificar que la opción exista
        if (opcion < 1 || opcion > comidas.Length)
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        // Guardar datos de la reserva
        nombres[contador] = nombre;
        asientos[contador] = asiento;
        reservas[contador] = comidas[opcion - 1];
        preciosReserva[contador] = precios[opcion - 1];

        // Sumar al total general
        totalGeneral += precios[opcion - 1];

        // Incrementar contador de reservas
        contador++;

        GuardarReservasArchivo();

        Console.WriteLine("\nReserva realizada correctamente.");
        Console.WriteLine("Total acumulado: $" + totalGeneral);
    }

    // MOSTRAR RESERVAS
    static void MostrarReservas()
    {
        Console.WriteLine("\n--- LISTA DE RESERVAS ---");

        // Verificar si existen reservas
        if (contador == 0)
        {
            Console.WriteLine("No existen reservas.");
            return;
        }

        // Recorrer y mostrar reservas
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine(
                (i + 1) + ". " +
                nombres[i] +
                " | Asiento: " +
                asientos[i] +
                " | " +
                reservas[i] +
                " | $" +
                preciosReserva[i]
            );
        }

        // Mostrar total acumulado
        Console.WriteLine("\nTOTAL GENERAL: $" + totalGeneral);
    }

    // CANCELAR RESERVA
    static void CancelarReserva()
    {
        // Mostrar reservas actuales
        MostrarReservas();

        // Verificar si hay reservas
        if (contador == 0)
        {
            return;
        }

        Console.Write("\nSeleccione el número de reserva a cancelar: ");

        int opcion;

        // Validar número ingresado
        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Debe ingresar un número válido.");
            return;
        }

        // Verificar que exista la reserva
        if (opcion < 1 || opcion > contador)
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        // Restar el precio eliminado del total
        totalGeneral -= preciosReserva[opcion - 1];

        // Reorganizar arreglos después de eliminar
        for (int i = opcion - 1; i < contador - 1; i++)
        {
            nombres[i] = nombres[i + 1];
            asientos[i] = asientos[i + 1];
            reservas[i] = reservas[i + 1];
            preciosReserva[i] = preciosReserva[i + 1];
        }

        // Reducir contador
        contador--;
        
        GuardarReservasArchivo();
        Console.WriteLine("Reserva cancelada correctamente.");
    }

    // CONTAR RESERVAS POR ASIENTO
    static int ContarReservasAsiento(string asiento)
    {
        int cantidad = 0;

        // Recorrer todos los asientos registrados
        for (int i = 0; i < contador; i++)
        {
            // Comparar asiento ignorando mayúsculas
            if (asientos[i].ToLower() == asiento.ToLower())
            {
                cantidad++;
            }
        }
        // Retornar cantidad encontrada
        return cantidad;
    }
    static void CargarReservasArchivo()
    {
        if (!File.Exists(archivo))
        {
            return;
        }

        StreamReader reader = new StreamReader(archivo);

        string linea;

        while ((linea = reader.ReadLine()) != null)
        {
            string[] datos = linea.Split('|');

            nombres[contador] = datos[0];
            asientos[contador] = datos[1];
            reservas[contador] = datos[2];
            preciosReserva[contador] = double.Parse(datos[3]);

            totalGeneral += preciosReserva[contador];

            contador++;
        }

        reader.Close();
    }
    static void GuardarReservasArchivo()
    {
        StreamWriter writer = new StreamWriter(archivo);

        for (int i = 0; i < contador; i++)
        {
            writer.WriteLine(
                nombres[i] + "|" +
                asientos[i] + "|" +
                reservas[i] + "|" +
                preciosReserva[i]
            );
        }

        writer.Close();
    }

}