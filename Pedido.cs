using System.Globalization;

public class Pedido
{
    public int NumPedido { get; set; }
    public string? Obs { get; set; }
    public Cliente cliente { get; private set; }
    public EstadoPedido Estado { get; private set; } = EstadoPedido.Pendiente;
    public Cadete CadeteAsignado { get; set; }
    
    public Pedido(int numPedido, string? obs, Cliente cliente, EstadoPedido estado = default, Cadete cadeteAsignado = null)
    {
        this.NumPedido = numPedido;
        this.Obs = obs;
        this.cliente = cliente;
        this.Estado = estado;
        this.CadeteAsignado = cadeteAsignado;
    }

    public string VerDireccionCliente()
    {
        return cliente.Direccion;
    }
    public string MostrarDatosCliente()
    {
        string DatosCliente = $"Nombre: {cliente.Nombre}\nDatos de Referencia: {cliente.DatosRefereciaDireccion}\nTelefono: "+ cliente.Telefono;
        return DatosCliente;
    }

    public void CambiarEstado(EstadoPedido NuevoEstado)
    {
        Estado = NuevoEstado;
    }

    public void VerDatosCliente()
    {
        Console.WriteLine(cliente);
    }
    public static string MostrarPedidos(List<Pedido> Pedidos)
    {
        string stringPedido = "Cargando Lista de Pedidos\n- - - -\n";
        foreach (var PedidoActual in Pedidos)
        {
            stringPedido = stringPedido + "Pedido: " + PedidoActual.NumPedido + " - Obs: " + PedidoActual.Obs + " - Estado: "
            + PedidoActual.Estado + PedidoActual.VerDatosCliente+ PedidoActual.VerDireccionCliente+ "\n- - - -\n";
        }
        return stringPedido;
    }

    public static void MostrarPedido(Pedido pedido)
    {

        Console.WriteLine();
        Console.WriteLine($"Pedido: {pedido.NumPedido} - Obs: {pedido.Obs} - Estado: {pedido.Estado}");
        pedido.VerDatosCliente();
        pedido.VerDireccionCliente();
    }

    public enum EstadoPedido
    {
        Entregado,
        Pendiente,
        Cancelado,
    }
}