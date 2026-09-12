using Objetos;

namespace GestionVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear al menos 3 vehiculos de distintos tipos

            Vehiculo auto = new Vehiculo("AB670CD", "Toyota", "Corolla", 15000, 2020, TipoVehiculo.Auto);
            Vehiculo suv = new Vehiculo("XY456ZT", "Jeep", "Compass", 22000, 2022, TipoVehiculo.SUV);
            Vehiculo premium = new Vehiculo("PQ789RS", "BMW", "Serie 5", 40000, 2023, TipoVehiculo.Premium);

            // Mostrando datos

            Console.WriteLine("=== Datos del auto ===");
            Console.WriteLine(auto.MostrarDatos());

            Console.WriteLine("=== Datos del SUV ===");
            Console.WriteLine(suv.MostrarDatos());

            Console.WriteLine("=== Datos del Premium ===");
            Console.WriteLine(premium.MostrarDatos());

            // Registro de recorrido

            auto.RegistrarRecorrido(500);
            Console.WriteLine($"Nuevo kilometraje del auto: {auto.Kilometraje} km");

            // Modifico la marca y modelo del SUV

            suv.Marca = "Jeep";
            suv.Modelo = "Renegade";
            Console.WriteLine($"Datos actualizados del SUV: {suv.Marca} {suv.Modelo}");

            // Modifico el precio base

            auto.PrecioBase = -500;
            Console.WriteLine($"Precio final del auto tras intento de precio invalido: {auto.PrecioFinal}");

            // Datos invalidos

            auto.Patente = "AB";
            Console.WriteLine($"Patente del auto tras intento invalido: {auto.Patente}");

            auto.PrecioBase = -500;
            Console.WriteLine($"Precio final del auto tras intento de precio inválido: ${auto.PrecioFinal}");

            // Usar metodo estatico
            Console.WriteLine($"¿'AB123CD' es una patente valida? {Vehiculo.EsPatenteValida("AB123CD")}");
            Console.WriteLine($"¿'AB' es una patente valida? {Vehiculo.EsPatenteValida("AB")}");

            // Datos Finales
            Console.WriteLine("=== Datos finales ===");
            Console.WriteLine(auto.MostrarDatos());
            Console.WriteLine(suv.MostrarDatos());
            Console.WriteLine(premium.MostrarDatos());
        }
    }
}
