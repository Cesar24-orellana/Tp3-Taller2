using System.Globalization;
using System.Linq;
public class Informe
{
    public static void InformePago(Cadeteria cadeteria, List<Pedido> ListaPedido)
    {
        int TotalPedidosEntregados = 0;
        int TotalPedidos = 0;
        double TotalJornada = 0;
        Console.WriteLine(" - - - Informe de Jornada - - -");
        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            int cantPedidosEntregados = Cadeteria.PedidosEntregados(cadete, ListaPedido);
            int cantPedidos = ListaPedido.Count;
            double JornalCobrar = Cadeteria.JornalACobrar(cadete.ID, ListaPedido);

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de pedidos: {cantPedidos}");
            Console.WriteLine($"Cantidad de pedidos entregados: {cantPedidosEntregados}");
            Console.WriteLine($"Jornal a cobrar: {JornalCobrar}");
            TotalPedidosEntregados += cantPedidosEntregados;
            TotalPedidos += cantPedidos;
            TotalJornada += JornalCobrar;
            Console.WriteLine("- - - -");
        }

        int CantidadCadetes = cadeteria.ListadoCadetes.Count;
        double PromedioEnvios = (double)TotalPedidosEntregados / CantidadCadetes;

        Console.WriteLine(" - - - Total - - -");
        Console.WriteLine($"Total de Envios: {TotalPedidos}");
        Console.WriteLine($"Total de Entregados: {TotalPedidosEntregados}");
        Console.WriteLine($"Total del Jornal a pagar: ${TotalJornada}");
        Console.WriteLine($"Promedio de envios por cadete: {PromedioEnvios:F2}");
    }
}