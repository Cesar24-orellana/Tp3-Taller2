using System.Globalization;

public class Cadete
{
    public int ID { get; private set; }
    public string? Nombre { get; private set; }
    public string? Direccion { get; private set; }
    public double Telefono { get; private set; }

    public Cadete(int iD, string? nombre, string? direccion, double telefono)
    {
        this.ID = iD;
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
    }

    public static string MostrarListaCadetes(List<Cadete> ListaCadetes)
    {
        string MensajeCadete = $"Cargando lista de cadetes: \n- - - -\n";
        foreach (var CadeteActual in ListaCadetes)
        {
            MensajeCadete += $"Cadete ID: {CadeteActual.ID} - Nombre: {CadeteActual.Nombre} - Dirección: {CadeteActual.Direccion} - Telefono: {CadeteActual.Telefono}\n"
                            + "- - - \n";
        }
        return MensajeCadete;
    }

    public static string MostrarCadete(Cadete cadete)
    {
        string MensajeCadete = $"Cargando Cadete\n - - - -\n"
                            + $"Cadete ID: {cadete.ID} - Nombre: {cadete.Nombre} - Dirección: {cadete.Direccion} - Telefono: {cadete.Telefono}" +
                            "\n- - - -";
        return MensajeCadete;
    }
}