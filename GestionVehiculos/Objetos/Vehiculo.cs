using System.Text;

namespace Objetos
{

    public enum TipoVehiculo
    {
        Auto,
        Utilitario,
        SUV,
        Premium
    }
    public class Vehiculo
    {
        // Atributos privados
        private string patente;
        private float precioBase;
        private int añoFabricacion;

        // Propiedad patente Get y Set

        public string Patente
        {
            get
            { 
                return patente;
            }
            set
            {
                bool esValido = true;
                if (string.IsNullOrWhiteSpace(value))
                {
                    esValido = false;
                }
                else if (value.Length < 6 || value.Length > 10)
                {
                    esValido = false;
                }
                if (esValido)
                {
                    patente = value;
                }
            }

        }

        // Propiedad precioBase Set
        public float PrecioBase
        {
            set
            {
                if (value < 0)
                {
                    precioBase = value;
                }
            }
        }

        // Propiedades autoimplementadas
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Kilometraje { get; private set; }

        // Propiedad año de fabricacion Get y Set
        public int AñoFabricacion
        {
            get
            {
                return añoFabricacion;
            }
            set
            {
                if (value > 1900 && value < 2026)
                {
                    añoFabricacion = value;
                }
            }
        }

        // Propiedad autoimplementada de tipo enum
        public TipoVehiculo Tipo { get; set; }

        public int Antiguedad
        {
            get
            {
                return 2026 - añoFabricacion;
            }
        }

        // Propiedad PrecioFinal Get
        public float PrecioFinal
        {
            get
            {
                float recargo = 0f;

                switch (Tipo)
                {
                    case TipoVehiculo.Auto:
                        recargo = 0f;
                        break;
                    case TipoVehiculo.Utilitario:
                        recargo = 0.10f;
                        break;
                    case TipoVehiculo.SUV:
                        recargo = 0.20f;
                        break;
                    case TipoVehiculo.Premium:
                        recargo = 0.35f;
                        break;
                }
                return precioBase + (precioBase * recargo);
            }
        }

        // Constructor

        public Vehiculo(string patente, string marca, string modelo, float precioBase, int añoFabricacion, TipoVehiculo Tipo)
        {
            this.Patente = patente;
            this.Marca = marca;
            this.Modelo = modelo;
            this.PrecioBase = precioBase;
            this.AñoFabricacion = añoFabricacion;
            this.Tipo = Tipo;
        }

        // Metodos de instacnai

        public void RegistrarRecorrido(int km)
        {
            if (km > 0)
            {
                Kilometraje += km;
            }
        }

        public string ObtenerDescripcionTipo()
        {
            switch (Tipo)
            {
                case TipoVehiculo.Auto:
                    return "Auto ideal para uso diario y transporte personal.";
                case TipoVehiculo.Utilitario:
                    return "Utilitario ideal para carga y transporte de mercaderia.";
                case TipoVehiculo.SUV:
                    return "SUV ideal para aventuras y transporte en todo terreno.";
                case TipoVehiculo.Premium:
                    return "Vehículo premium con caracteristicas de lujo.";
            }
            return "Tipo de vehículo no reconocido.";
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Patente: {Patente}");
            sb.AppendLine($"Marca: {Marca}");
            sb.AppendLine($"Modelo: {Modelo}");
            sb.AppendLine($"Año de Fabricación: {AñoFabricacion}");
            sb.AppendLine($"Tipo: {Tipo}");
            sb.AppendLine($"Kilometraje: {Kilometraje}");
            sb.AppendLine($"Antigüedad: {Antiguedad}");
            sb.AppendLine($"Descripcion: {ObtenerDescripcionTipo()}");
            sb.AppendLine($"Precio Final: {PrecioFinal}");

            return sb.ToString();
        }

        // Metodo estatico

        public static bool EsPatenteValida(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
            {
                return false;
            }
            if (patente.Length < 6 || patente.Length > 10)
            {
                return false;
            }
            return true;
        }






    }
}
