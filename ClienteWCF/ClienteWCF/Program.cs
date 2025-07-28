using ListaAmigosServiceRef;
using System;
using System.Threading.Tasks;

class Program
{
    static ListaAmigosServiceClient cliente = new ListaAmigosServiceClient();

    static async Task Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("📋 Menú Lista de Amigos");
            Console.WriteLine("1. Agregar amigo");
            Console.WriteLine("2. Listar todos los amigos");
            Console.WriteLine("3. Buscar por alias");
            Console.WriteLine("4. Cambiar estado (activo/inactivo)");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await AgregarAmigo();
                    break;
                case "2":
                    await ListarAmigos();
                    break;
                case "3":
                    await BuscarAmigo();
                    break;
                case "4":
                    await CambiarEstado();
                    break;
                case "5":
                    salir = true;
                    await cliente.CloseAsync();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static async Task AgregarAmigo()
    {
        Console.Write("Alias: ");
        string alias = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("¿Está activo? (s/n): ");
        bool activo = Console.ReadLine().Trim().ToLower() == "s";

        var nuevo = new Amigo
        {
            Alias = alias,
            Nombre = nombre,
            EsActivo = activo
        };

        await cliente.AgregarAmigoAsync(nuevo);
        Console.WriteLine("✅ Amigo agregado exitosamente.");
    }

    static async Task ListarAmigos()
    {
        var amigos = await cliente.ObtenerAmigosAsync();

        if (amigos.Length == 0)
        {
            Console.WriteLine("⚠️ No hay amigos registrados.");
            return;
        }

        Console.WriteLine("\n📃 Lista de amigos:");
        foreach (var a in amigos)
        {
            Console.WriteLine($"- {a.Nombre} ({a.Alias}) - {(a.EsActivo ? "Activo" : "Inactivo")}");
        }
    }

    static async Task BuscarAmigo()
    {
        Console.Write("Ingresa el alias a buscar: ");
        string alias = Console.ReadLine();

        var amigo = await cliente.BuscarPorAliasAsync(alias);
        if (amigo == null)
        {
            Console.WriteLine("❌ Amigo no encontrado.");
        }
        else
        {
            Console.WriteLine($"✅ Encontrado: {amigo.Nombre} - {(amigo.EsActivo ? "Activo" : "Inactivo")}");
        }
    }

    static async Task CambiarEstado()
    {
        Console.Write("Alias del amigo: ");
        string alias = Console.ReadLine();

        Console.Write("¿Nuevo estado activo? (s/n): ");
        bool nuevoEstado = Console.ReadLine().Trim().ToLower() == "s";

        bool resultado = await cliente.CambiarEstadoAsync(alias, nuevoEstado);
        if (resultado)
            Console.WriteLine("✅ Estado actualizado correctamente.");
        else
            Console.WriteLine("❌ No se pudo actualizar. ¿Alias incorrecto?");
    }
}
