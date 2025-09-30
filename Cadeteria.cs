using System.Globalization;

public class Cadeteria
{
    private string? Nombre { get; set; }
    private double Telefono { get; set; }
    public List<Cadete> ListadoCadetes;
    public List<Pedido> ListadoPedidos{ get; }

    public Cadeteria(string? nombre, double telefono, List<Cadete> listadoCadetes, List<Pedido> listadoPedidos)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.ListadoCadetes = listadoCadetes;
        this.ListadoPedidos = listadoPedidos;
    }

    public static void ReasignarPedido(Cadeteria cadeteria, Cadete cadete, Pedido pedido)
    {
        foreach (var PedidoActual in cadeteria.ListadoPedidos)
        {
            if (PedidoActual == pedido)
            {
                PedidoActual.CadeteAsignado = cadete;
            }
        }
    }

    public static double JornalACobrar(int Id, List<Pedido> ListaPedidos)
    {
        return ListaPedidos
            .Where(p => p.CadeteAsignado?.ID == Id && p.Estado == Pedido.EstadoPedido.Entregado)
            .Count() * 500;
    }
    public static int PedidosEntregados(Cadete cadete, List<Pedido> ListaPedidos)
    {
        int CantEntregados = 0;
        foreach (var PedidoActual in ListaPedidos)
        {
            if (PedidoActual.Estado == Pedido.EstadoPedido.Entregado && PedidoActual.CadeteAsignado == cadete)
            {
                CantEntregados++;
            }
        }
        return CantEntregados;
    }

    public static void CambiarEstado(Pedido pedido, Pedido.EstadoPedido NuevoEstado)
    {
        pedido.CambiarEstado(NuevoEstado);
    }

    public void AsignarCadeteAPedido(int IdCadete, int IdPedido)
    {
        var cadete = ListadoCadetes.FirstOrDefault(p => p.ID == IdCadete);
        var pedido = ListadoPedidos.FirstOrDefault(p => p.NumPedido == IdPedido);

        if (pedido != null && cadete != null)
        {
            pedido.CadeteAsignado = cadete;
        }
        else
        {
            Console.WriteLine("Cadete o Pedido no encontrado");
        }
    }

    public static Pedido DarDeAlta(int numero, string? obs, string? nombre, string? direccion, double telefono, string? datosRef)
    {
        var NuevoCliente = new Cliente(nombre, direccion, telefono, datosRef);
        var nuevoPedido = new Pedido(numero, obs, NuevoCliente, Pedido.EstadoPedido.Pendiente);
        return nuevoPedido;
    }
}