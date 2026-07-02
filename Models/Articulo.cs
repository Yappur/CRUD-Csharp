public class Articulo
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal MontoPrestado { get; set; }
    public int DiasPlazo { get; set; }
    public DateTime FechaIngreso { get; set; }

    public int DiasTranscurridos
    {
        get
        {
            int dias = (DateTime.Today - FechaIngreso.Date).Days;
            return dias < 0 ? 0 : dias;
        }
    }

    public decimal InteresAcumulado => MontoPrestado * 0.02m * DiasTranscurridos;

    public decimal TotalAdeudado => MontoPrestado + InteresAcumulado;
}
