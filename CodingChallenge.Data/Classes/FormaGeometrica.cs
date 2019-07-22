/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica : Traduccion
    {

        protected decimal _lado;
        protected static int CantidadTotal;
        protected static decimal AreasTotal;
        protected static decimal PerimetrosTotal;


        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public FormaGeometrica() { }

        public FormaGeometrica(decimal ancho)
        {
            _lado = ancho;
        }

        public FormaGeometrica(decimal ancho, decimal altura)
        {
        }

        public FormaGeometrica(
            decimal baseSuperior, 
            decimal baseInferior, 
            decimal ladoIzquierdo, 
            decimal ladoDerecho,
            decimal altura)
        {
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(PrintEmptyList(idioma));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER

                sb.Append(PrintHeader(idioma));

                for (var i = 0; i < formas.Count; i++)
                {
                    formas[i].IncrementarCantidad();
                    formas[i].CalcularArea();
                    formas[i].CalcularPerimetro();
                }

                sb.Append(Square.ObtenerLineaDeClase(idioma));
                sb.Append(Circle.ObtenerLineaDeClase(idioma));
                sb.Append(Triangle.ObtenerLineaDeClase(idioma));
                sb.Append(Rectangle.ObtenerLineaDeClase(idioma));
                sb.Append(Trapezoid.ObtenerLineaDeClase(idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(CantidadTotal + " " + TraducirForma(idioma) + " ");
                sb.Append((TraducirPerimetro(idioma) + " ") + (PerimetrosTotal).ToString("#.##") +" ");
                sb.Append(TraducirArea(idioma) + " " + (AreasTotal).ToString("#.##"));
            }

            RestartCounters();

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public virtual decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public virtual decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public virtual void IncrementarCantidad()
        { }

        private static void RestartCounters()
        {
            CantidadTotal = 0;
            AreasTotal = 0;
            PerimetrosTotal = 0;
        }
    }
}
