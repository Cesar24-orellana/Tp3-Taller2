using System.Globalization;
using System.Collections.Generic;

var NuevoCliente = new Cliente("Miguel Angel", "Entrega Inmediata", 3813649582, "Auto azul en la entrada");
var NuevoPedido=new Pedido(
                        1, "Entrega Inmediata", NuevoCliente,
                        Pedido.EstadoPedido.Pendiente
);


NuevoPedido.VerDatosCliente();
NuevoPedido.VerDireccionCliente();
Console.WriteLine("- - - -");

// Cargar lista con archivo CSV
string ArchivoPedido = "pedidos.csv";
string ArchivoCadete = "cadetes.csv";

IAccesoADatos<Pedido> accesoPedido;
IAccesoADatos<Cadete> accesoCadete;

Console.WriteLine("Desea cargar las listas con archivo: \n1_ csv o 2_ Json");
string? seleccion = Console.ReadLine();
if (seleccion == "1")
{
    accesoPedido = new AccesoADatosCSV<Pedido>();
    accesoCadete = new AccesoADatosCSV<Cadete>();
}
else
{
    accesoPedido = new AccesoADatosJSON<Pedido>();
    accesoCadete = new AccesoADatosJSON<Cadete>();
    ArchivoPedido = ArchivoPedido.Replace(".csv", ".json");
    ArchivoCadete = ArchivoCadete.Replace(".csv", ".json");
}

var ListaPedidos = accesoPedido.Cargar(ArchivoPedido);
// Cargar lista de cadetes
var ListaCadetes = accesoCadete.Cargar(ArchivoCadete);


// Crear Nuevos Cadetes
var Cadete1 = new Cadete(1, "Manuel", "Calle Nueva Esperanza", 3816549684);

ListaPedidos.Add(NuevoPedido);
ListaCadetes.Add(Cadete1);

var NuevaCadeteria = new Cadeteria("Cadeteria Don Juan", 545645456, ListaCadetes, ListaPedidos);

Random random = new Random();
foreach (var pedido in ListaPedidos)
{
    if (ListaCadetes.Count != 0 && ListaPedidos != null)
    {
        int idCadete = random.Next(ListaCadetes.Count);
        string asignar = NuevaCadeteria.AsignarPedido(idCadete, pedido.NumPedido);
        int nuevoEstado = random.Next(0, 2);
        string estado = NuevaCadeteria.CambiarEstado(pedido.NumPedido, nuevoEstado);
    }
}
Console.WriteLine(NuevaCadeteria.ListadoCadetes);
Console.WriteLine("- - - -");
Console.WriteLine(NuevaCadeteria.ListaPedidoString);
Console.WriteLine(NuevaCadeteria.AsignarPedido(1,1));

Informe.InformePago(NuevaCadeteria, ListaPedidos);
