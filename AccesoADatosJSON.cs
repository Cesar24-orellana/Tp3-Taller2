using System.Globalization;
using System.Linq;
using System.Text.Json;
public class AccesoADatosJSON<T> : IAccesoADatos<T>
{
    public List<T> Cargar(string archivo)
    {
        if (!File.Exists(archivo))
        {
            Console.WriteLine($"El archivo {archivo} no fue encontrado!!");
            return new List<T>();
        }

        string textoJson = File.ReadAllText(archivo);
        return JsonSerializer.Deserialize<List<T>>(textoJson) ?? new List<T>();
    }
}