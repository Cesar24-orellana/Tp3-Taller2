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

    /* public static string MostrarPedidos(List<Pedido> Pedidos)
    {
        string stringPedido = "Cargando Lista de Pedidos\n- - - -\n";
        foreach (var PedidoActual in Pedidos)
        {
            stringPedido = stringPedido + "Pedido: " + PedidoActual.NumPedido + " - Obs: " + PedidoActual.Obs + " - Estado: "
            + PedidoActual.Estado + $"\n{PedidoActual.VerDatosCliente}" + $"\n{PedidoActual.VerDireccionCliente}";
            if (PedidoActual.CadeteAsignado != null)
            {
                stringPedido += $"\nCadete Asignado: {PedidoActual.CadeteAsignado}\n";
            }
            stringPedido += "- - - -\n";
        }
        return stringPedido;
    } */

    public object MostrarPedido()
    {
        string pedidoString = $"Pedido: {NumPedido} - Obs: {Obs} - Estado: {Estado}\n";
        pedidoString += $"{VerDatosCliente} {VerDireccionCliente} \nCadete Asignado: {CadeteAsignado}";
        return pedidoString;
    }

    public enum EstadoPedido
    {
        Entregado,
        Pendiente,
        Cancelado,
    }
}