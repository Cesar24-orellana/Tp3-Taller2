using System.Globalization;

public class Cadeteria
{
    public string? Nombre { get; private set; }
    public double Telefono { get; private set; }
    public List<Cadete> ListadoCadetes{ get; private set;}
    public List<Pedido> ListadoPedidos{ get; private set;}

    public Cadeteria(string? nombre, double telefono, List<Cadete> listadoCadetes, List<Pedido> listadoPedidos)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.ListadoCadetes = listadoCadetes;
        this.ListadoPedidos = listadoPedidos;
    }

    public string AsignarPedido(int idCadete, int numPedido)
    {
        var pedido = ListadoPedidos.FirstOrDefault(p=>p.NumPedido == numPedido);
        var cadete = ListadoCadetes.FirstOrDefault(j=>j.ID == idCadete);
        if (pedido == null || cadete == null) return "cadete o pedido no existe!!";
        pedido.CadeteAsignado = cadete;
        return "Cadete fue asignado con exito!!";
    }

    public double JornalACobrar(int Id)
    {
        return ListadoPedidos
            .Where(p => p.CadeteAsignado?.ID == Id && p.Estado == Pedido.EstadoPedido.Entregado)
            .Count() * 500;
    }

    public int PedidosEntregados(int idCadete)
    {
        var cadete = ListadoCadetes.FirstOrDefault(p=>p.ID == idCadete);
        if (cadete == null) return 0;
        int CantEntregados = 0;
        foreach (var PedidoActual in ListadoPedidos)
        {
            if (PedidoActual.Estado == Pedido.EstadoPedido.Entregado && PedidoActual.CadeteAsignado == cadete)
            {
                CantEntregados++;
            }
        }
        return CantEntregados;
    }

    public string CambiarEstado(int numPedido, Pedido.EstadoPedido NuevoEstado)
    {
        var pedido = ListadoPedidos.FirstOrDefault(p => p.NumPedido == numPedido);
        if (pedido == null) return "Pedido no encontrado";
        else pedido.CambiarEstado(NuevoEstado);
        return "Pedido encontrado y actualizado";
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