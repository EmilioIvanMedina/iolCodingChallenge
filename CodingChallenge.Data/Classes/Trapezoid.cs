using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapezoid: FormaGeometrica
    {
        protected decimal _baseSuperior;
        protected decimal _baseInferior;
        protected decimal _ladoIzquierdo;
        protected decimal _ladoDerecho;
        protected decimal _alto;
        private static int Cantidad;
        private static decimal Areas;
        private static decimal Perimetros;

        public Trapezoid(
            decimal baseSuperior,
            decimal baseInferior,
            decimal ladoIzquierdo,
            decimal ladoDerecho,
            decimal altura) : base(baseSuperior, baseInferior, ladoIzquierdo,ladoDerecho, altura)
        {
            Tipo = Trapecio;
            _baseInferior= baseInferior;
            _baseSuperior = baseSuperior;
            _ladoDerecho = ladoDerecho;
            _ladoIzquierdo = ladoIzquierdo;
            _alto = altura;
        }

        public override decimal CalcularArea()
        {
            decimal area = _alto * ((_baseSuperior + _baseInferior) / 2);
            Areas += area;
            AreasTotal += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal perimetro = _baseInferior + _baseSuperior + _ladoDerecho + _ladoIzquierdo;
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
            string result = ObtenerLinea(Cantidad, Areas, Perimetros, FormaGeometrica.Trapecio, idioma);
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
