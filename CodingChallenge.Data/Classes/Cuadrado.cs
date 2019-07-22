using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private static int Cantidad;
        private static decimal Areas;
        private static decimal Perimetros;

        public Cuadrado(decimal ancho) : base(ancho)
        {
            _lado = ancho;
            Tipo = Cuadrado;
        }


        public override decimal CalcularArea()
        {
            decimal area = _lado * _lado;
            Areas += area;
            AreasTotal += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal perimetro = _lado * 4;
            Perimetros += perimetro;
            PerimetrosTotal += perimetro;
            return perimetro;
        }

        public override void IncrementarCantidad()
        {
            Cantidad++;
            CantidadTotal++;
        }

        public static string ObtenerLineaDeClase(int idioma)
        {
            string result = ObtenerLinea(Cantidad, Areas, Perimetros, FormaGeometrica.Cuadrado, idioma);
            RestartCounters();
            return result;
        }

        private static void RestartCounters()
        {
            Cantidad = 0;
            Areas = 0;
            Perimetros = 0;
        }
    }
}
