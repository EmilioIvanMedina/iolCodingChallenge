using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Triangulo : FormaGeometrica
    {
        private static int Cantidad;
        private static decimal Areas;
        private static decimal Perimetros;

        public Triangulo(decimal ancho) : base(ancho)
        {
            _lado = ancho;
            Tipo = TrianguloEquilatero;
        }

        public override decimal CalcularArea()
        {
            decimal area = ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
            Areas += area;
            AreasTotal += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal perimetro = _lado * 3;
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
    }
}
