public class ArticuloService
{
  private string ruta = "empeños.txt";

  public List<Articulo> ObtenerArticulos()
  {
 List<Articulo> articulos = new List<Articulo>();
  if (File.Exists(ruta)) return articulos;

  string[] lineas = File.ReadAllLines(ruta);

  foreach{}

return articulos;
  }

  public void Crear(Articulo articulo)
  {

  }

  public void Eliminar(int id)
  {

  }
}