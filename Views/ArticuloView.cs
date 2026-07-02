public class ArticuloView
{
    private readonly ArticuloService servicio;

    public ArticuloView(ArticuloService servicio)
    {
        this.servicio = servicio;
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("=== Control de empeños ===");
            Console.WriteLine("1. Registrar objeto empeñado");
            Console.WriteLine("2. Listar articulos en deposito");
            Console.WriteLine("3. Liquidar deuda");
            Console.WriteLine("4. Editar articulo");
            Console.WriteLine("0. Salir");
            opcion = LeerEntero("Opcion: ");

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    RegistrarArticulo();
                    break;
                case 2:
                    ListarArticulos();
                    break;
                case 3:
                    LiquidarDeuda();
                    break;
                case 4:
                    EditarArticulo();
                    break;
                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta.");
                    break;
            }
        }
        while (opcion != 0);
    }

    private void RegistrarArticulo()
    {
        Articulo articulo = new();

        articulo.Id = servicio.ProximoId();
        Console.WriteLine($"Id asignado: {articulo.Id}");

        Console.Write("Descripcion: ");
        articulo.Descripcion = Console.ReadLine()!;

        articulo.MontoPrestado = LeerDecimal("Monto prestado: ");

        articulo.DiasPlazo = LeerEntero("Dias de plazo: ");

        articulo.FechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");

        servicio.CrearArticulo(articulo);
        Console.WriteLine("Articulo registrado correctamente.");
    }

    private void ListarArticulos()
    {
        List<Articulo> articulos = servicio.ObtenerArticulos();

        if (articulos.Count == 0)
        {
            Console.WriteLine("No hay articulos cargados.");
            return;
        }

        foreach (Articulo articulo in articulos)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Id: {articulo.Id}");
            Console.WriteLine($"Descripcion: {articulo.Descripcion}");
            Console.WriteLine($"Monto prestado: ${articulo.MontoPrestado}");
            Console.WriteLine($"Dias de plazo: {articulo.DiasPlazo}");
            Console.WriteLine($"Fecha de ingreso: {articulo.FechaIngreso:dd/MM/yyyy}");
            Console.WriteLine($"Interes acumulado: ${articulo.InteresAcumulado}");
            Console.WriteLine($"Total a pagar: ${articulo.TotalAdeudado}");
        }
    }

    private void LiquidarDeuda()
    {
        int id = LeerEntero("Ingrese el Id del articulo a retirar: ");

        servicio.LiquidarDeudaArticulo(id);
        Console.WriteLine("Deuda liquidada. El articulo fue eliminado del archivo.");
    }

    private void EditarArticulo()
    {
        int id = LeerEntero("Ingrese el Id del articulo a editar: ");
        Articulo? articulo = servicio.ObtenerArticulosPorId(id);

        if (articulo == null)
        {
            Console.WriteLine("No existe un articulo con ese Id.");
            return;
        }

        Console.WriteLine($"Descripcion actual: {articulo.Descripcion}");
        Console.Write("Nueva descripcion: ");
        string descripcion = Console.ReadLine()!;

        articulo.Descripcion = string.IsNullOrWhiteSpace(descripcion) ? articulo.Descripcion : descripcion;
        articulo.MontoPrestado = LeerDecimal($"Monto prestado ({articulo.MontoPrestado}): ");
        articulo.DiasPlazo = LeerEntero($"Dias de plazo ({articulo.DiasPlazo}): ");
        articulo.FechaIngreso = LeerFecha($"Fecha de ingreso (dd/mm/aaaa) ({articulo.FechaIngreso:dd/MM/yyyy}): ");

        if (servicio.ActualizarArticulo(articulo))
        {
            Console.WriteLine("Articulo actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el articulo.");
        }
    }

    private static int LeerEntero(string mensaje)
    {
        int numero;

        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Ingrese un numero valido: ");
        }

        return numero;
    }

    private static decimal LeerDecimal(string mensaje)
    {
        decimal numero;

        Console.Write(mensaje);
        while (!decimal.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Ingrese un monto valido: ");
        }

        return numero;
    }

    private static DateTime LeerFecha(string mensaje)
    {
        DateTime fecha;

        Console.Write(mensaje);
        while (!DateTime.TryParse(Console.ReadLine(), out fecha))
        {
            Console.Write("Ingrese una fecha valida: ");
        }

        return fecha;
    }
}
