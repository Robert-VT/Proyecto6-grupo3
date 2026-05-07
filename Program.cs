using System;
using System.IO;
using System.Linq;
public class Donacion
{
    public string NumeroComprobante { get; set; }
    public DateTime FechaRecepcion { get; set; }
    public string Donante { get; set; }
    public string TipoDonacion { get; set; }
    public double ValorEstimado { get; set; }
    public string DestinoAsignado { get; set; }
    public bool EstadoDistribuido { get; set; }
    public DateTime? FechaDistribucion { get; set; }

    public Donacion(string numeroComprobante, DateTime fechaRecepcion, string donante,
        string tipoDonacion, double valorEstimado, string destinoAsignado,
        bool estadoDistribuido, DateTime? fechaDistribucion)
    {
        NumeroComprobante = numeroComprobante;
        FechaRecepcion = fechaRecepcion;
        Donante = donante;
        TipoDonacion = tipoDonacion;
        ValorEstimado = valorEstimado;
        DestinoAsignado = destinoAsignado;
        EstadoDistribuido = estadoDistribuido;
        FechaDistribucion = fechaDistribucion;
    }
}

class Programa
{
    static Donacion[] donaciones = new Donacion[50];
    static int contador = 0;

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n=== Transparencia-Local ===");
            Console.WriteLine("1. Registrar Donacion");
            Console.WriteLine("2. Buscar Donacion");
            Console.WriteLine("3. Listar Pendientes");
            Console.WriteLine("4. Reporte Trimestral");
            Console.WriteLine("5. Estadisticas");
            Console.WriteLine("6. Exportar a CSV");
            Console.WriteLine("7. Reorganizar Donaciones");
            Console.WriteLine("0. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida.");
                continue;
            }

            switch (opcion)
            {
                case 1: RegistrarDonacion(); break;
                case 2: BuscarDonacion(); break;
                case 3: ListarPendientes(); break;
                case 4: GenerarReporteTrimestral(); break;
                case 5: MostrarEstadisticas(); break;
                case 6: ExportarCSV(); break;
                case 7: ReorganizarDonaciones(); break;
            }

        } while (opcion != 0);
    }

    static void RegistrarDonacion()
    {
        try
        {
            if (contador >= donaciones.Length)
            {
                Console.WriteLine("No hay espacio para mas donaciones.");
                return;
            }

            string comprobante = $"DON-{contador + 1:D4}";
            DateTime fecha = DateTime.Now;
            Console.WriteLine($"Fecha y hora automática: {fecha:yyyy-MM-dd HH:mm}");

            Console.Write("Donante: ");
            string donante = Console.ReadLine();

            Console.Write("Tipo de donacion: ");
            string tipo = Console.ReadLine();

            Console.Write("Valor estimado: ");
            double valor = double.Parse(Console.ReadLine());

            if (valor < 0)
                throw new Exception("El valor debe ser >= 0.");

            Console.Write("Destino asignado: ");
            string destino = Console.ReadLine();

            Donacion d = new Donacion(comprobante, fecha, donante, tipo, valor, destino, false, null);
            donaciones[contador++] = d;

            Console.WriteLine("Donacion registrada correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void BuscarDonacion()
    {
        Console.Write("Ingrese comprobante o donante: ");
        string criterio = Console.ReadLine();

        var resultados = donaciones
            .Where(d => d != null &&
                   (d.NumeroComprobante == criterio ||
                    d.Donante.ToLower().Contains(criterio.ToLower())))
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("No se encontraron resultados.");
            return;
        }

        foreach (var d in resultados)
        {
            Console.WriteLine($"{d.NumeroComprobante} - {d.Donante} - {d.TipoDonacion} - {d.ValorEstimado}");
        }
    }

    static void ListarPendientes()
    {
        var pendientes = donaciones.Where(d => d != null && !d.EstadoDistribuido);

        foreach (var d in pendientes)
        {
            Console.WriteLine($"{d.NumeroComprobante} - {d.Donante} - {d.TipoDonacion}");
        }
    }

    static void GenerarReporteTrimestral()
    {
        Directory.CreateDirectory("reportes_transparencia");

        double total = donaciones.Where(d => d != null).Sum(d => d.ValorEstimado);
        int cantidad = donaciones.Count(d => d != null);

        string reporte = "=== Reporte Trimestral ===\n";
        reporte += $"Total recibido: {total}\n";
        reporte += $"Cantidad de donaciones: {cantidad}\n";

        string ruta = $"reportes_transparencia/reporte_{DateTime.Now:yyyyMMdd}.txt";
        File.WriteAllText(ruta, reporte);

        Console.WriteLine("Reporte generado en: " + ruta);
    }

    static void MostrarEstadisticas()
    {
        var top = donaciones.Where(d => d != null)
            .GroupBy(d => d.Donante)
            .Select(g => new
            {
                Donante = g.Key,
                Total = g.Sum(x => x.ValorEstimado)
            })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault();

        if (top != null)
        {
            Console.WriteLine($"Donante principal: {top.Donante} con {top.Total}");
        }
        else
        {
            Console.WriteLine("No hay datos.");
        }
    }

    static void ExportarCSV()
    {
        string ruta = "donaciones.csv";

        using (StreamWriter sw = new StreamWriter(ruta))
        {
            sw.WriteLine("Comprobante,Fecha,Donante,Tipo,Valor,Destino,Distribuido,FechaDistribucion");

            foreach (var d in donaciones.Where(x => x != null))
            {
                sw.WriteLine($"{d.NumeroComprobante},{d.FechaRecepcion:yyyy-MM-dd HH:mm},{d.Donante},{d.TipoDonacion},{d.ValorEstimado},{d.DestinoAsignado},{d.EstadoDistribuido},{d.FechaDistribucion}");
            }
        }

        Console.WriteLine("CSV generado en: " + ruta);
    }

    static void ReorganizarDonaciones()
    {
        Console.WriteLine("=== Reorganizacion ===");
        Console.WriteLine("1. Mas recientes");
        Console.WriteLine("2. Mas antiguas");
        Console.WriteLine("3. Mayor cantidad");
        Console.WriteLine("4. Menor cantidad");

        int criterio;
        if (!int.TryParse(Console.ReadLine(), out criterio))
        {
            Console.WriteLine("Opcion invalida.");
            return;
        }

        var lista = donaciones.Where(d => d != null);

        switch (criterio)
        {
            case 1:
                lista = lista.OrderByDescending(d => d.FechaRecepcion);
                break;
            case 2:
                lista = lista.OrderBy(d => d.FechaRecepcion);
                break;
            case 3:
                lista = lista.OrderByDescending(d => d.ValorEstimado);
                break;
            case 4:
                lista = lista.OrderBy(d => d.ValorEstimado);
                break;
        }

        Console.WriteLine("=== Donaciones reorganizadas ===");

        foreach (var d in lista)
        {
            Console.WriteLine($"{d.NumeroComprobante} - {d.FechaRecepcion:yyyy-MM-dd HH:mm} - {d.Donante} - {d.ValorEstimado}");
        }
    }
}