using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private static int Cantidad;
        private static decimal Areas;
        private static decimal Perimetros;

        public Circulo(decimal ancho) : base(ancho)
        {
            _lado = ancho;
            Tipo = Circulo;
        }

        public override decimal CalcularArea()
        {
            decimal area = (decimal)Math.PI * (_lado / 2) * (_lado / 2);
            Areas += area;
            AreasTotal += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal perimetro = (decimal)Math.PI * _lado;
            Perimetros += perimetro;
            PerimetrosTotal += perimetro; 
            return perimetro;
        }

        public override void IncrementarCantidad()
        {
            Cantidad++;
            CantidadTotal++;
        }

        public static int GetCantidad()
        { return Cantidad; }

        public static decimal GetTotalAreas()
        { return Areas; }

        public static decimal GetTotalPerimetros()
        { return Perimetros; }

        public static string ObtenerLineaDeClase(int idioma)
        {
            if (GetCantidad() > 0)
            {
                string linea;
                if (idioma == Castellano)
                    linea = $"{GetCantidad()} {TraducirFormaDeClase(GetCantidad(), idioma)} | " +
                        $"Area {GetTotalAreas():#.##} | " +
                        $"Perimetro {GetTotalPerimetros():#.##} <br/>";
                else
                    linea = $"{GetCantidad()} {TraducirFormaDeClase(GetCantidad(), idioma)} | " +
                        $"Area {GetTotalAreas():#.##} | " +
                        $"Perimeter {GetTotalPerimetros():#.##} <br/>";

                RestartCounters();
                return linea;
            }
            else
            {
                return string.Empty;
            }
        }

        private static string TraducirFormaDeClase(int cantidad, int idioma)
        {
            if (idioma == Castellano)
                return cantidad == 1 ? "Círculo" : "Círculos";
            else
                return cantidad == 1 ? "Circle" : "Circles";
        }

        private static void RestartCounters()
        {
            Cantidad = 0;
            Areas = 0;
            Perimetros = 0;
        }
    }
}

