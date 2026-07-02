public class ArticuloService
{
    private const string Archivo = "empeños.txt";

    // Get o READ
    public List<Articulo> ObtenerArticulos()
    {
        List<Articulo> articulos = new();

        if (!File.Exists(Archivo))
        {
            return articulos;
        }

        foreach (string linea in File.ReadAllLines(Archivo))
        {
            string[] datos = linea.Split('|');

            if (datos.Length == 5)
            {
                Articulo articulo = new()
                {
                    Id = int.Parse(datos[0]),
                    Descripcion = datos[1],
                    MontoPrestado = decimal.Parse(datos[2]),
                    DiasPlazo = int.Parse(datos[3]),
                    FechaIngreso = DateTime.Parse(datos[4])
                };

                articulos.Add(articulo);
            }
        }

        return articulos;
    }

    // GET para obtener por ID
    public Articulo? ObtenerArticulosPorId(int id)
    {
        return ObtenerArticulos().FirstOrDefault(a => a.Id == id);
    }

    // create o POST 
    public void CrearArticulo(Articulo articulo)
    {
        List<Articulo> articulos = ObtenerArticulos();

        if (articulos.Any(a => a.Id == articulo.Id))
        {
            Console.WriteLine("Ya existe un articulo con ese Id.");
            return;
        }

        articulos.Add(articulo);
        GuardarTodos(articulos);
    }

    // upadte o PUT buscamos reemplazar los datos de un articulo existente. usamos su id para encontrarlo
    public bool ActualizarArticulo(Articulo articulo)
    {
        List<Articulo> articulos = ObtenerArticulos();

        int indice = articulos.FindIndex(a => a.Id == articulo.Id);         // posicion de la lista que queremos reemplazar

        if (indice == -1)
        {
            Console.WriteLine("No existe un articulo con ese Id.");
            return false;
        }

        articulos[indice] = articulo;         // pisamos el articulo viejo con el nuevo, en la misma posicion para actualizarlo
        GuardarTodos(articulos);
        return true;
    }

    public void LiquidarDeudaArticulo(int id)
    {
        List<Articulo> articulos = ObtenerArticulos();
        articulos.RemoveAll(a => a.Id == id);
        GuardarTodos(articulos);
    }


    // -- metodos de negocio
    // no son CRUDs como si, son operaciones que nos ayudaran a resolver el problema.
    // parecen cruds pero afuera se leen con el lenguaje del negocio.
    public int ProximoId()
    {
        List<Articulo> articulos = ObtenerArticulos();
        return articulos.Count == 0 ? 1 : articulos.Max(a => a.Id) + 1;
    }


    // persistencia de datos
    // reescribe todo el archivo con la lista completa
    // lo usamos al final de las operaciones crear, actualizar y eliminar 
    // para mantener el archivo sincronizado con la lista de articulos
    private static void GuardarTodos(List<Articulo> articulos)
    {
        List<string> lineas = new();

        foreach (Articulo articulo in articulos)
        {
            string linea = $"{articulo.Id}|{articulo.Descripcion}|{articulo.MontoPrestado}|{articulo.DiasPlazo}|{articulo.FechaIngreso:yyyy-MM-dd}";
            lineas.Add(linea);
        }

        File.WriteAllLines(Archivo, lineas);
    }
}
