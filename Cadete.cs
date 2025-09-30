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

    public static void MostrarListaCadetes(List<Cadete> ListaCadetes)
    {
        Console.WriteLine("Cargando lista de cadetes: ");
        Console.WriteLine("- - - - - -");
        foreach (var CadeteActual in ListaCadetes)
        {
            Console.WriteLine($"Cadete ID: {CadeteActual.ID} - Nombre: {CadeteActual.Nombre} - Dirección: {CadeteActual.Direccion} - Telefono: {CadeteActual.Telefono}");
            //Pedido.MostrarPedidos(CadeteActual.ListadoPedidos);
            Console.WriteLine("- - - - - -");
        }
    }

    public static void MostrarCadete(Cadete cadete)
    {
        Console.WriteLine("Cargando Cadete");
        Console.WriteLine("- - - - - -");
        Console.WriteLine($"Cadete ID: {cadete.ID} - Nombre: {cadete.Nombre} - Dirección: {cadete.Direccion} - Telefono: {cadete.Telefono}");
        //Pedido.MostrarPedidos(cadete.ListadoPedidos);
        Console.WriteLine("- - - - - -");
    }
}