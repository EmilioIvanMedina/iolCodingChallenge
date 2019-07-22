using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Traduccion
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Rectangulo = 4;
        public const int Trapecio = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;
        public const int Portugues = 4;

        #endregion
        public Traduccion() { }

        public static string PrintEmptyList(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return "<h1>Lista vacía de formas!</h1>";
                case Portugues:
                    return "<h1>Lista vazia de formas!</h1>";
                case Italiano:
                    return "<h1>Lista vuota di forme!</h1>";
                default:
                    return "<h1>Empty list of shapes!</h1>";
            }
        }
        public static string PrintHeader(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return "<h1>Reporte de Formas</h1>";
                case Portugues:
                    return "<h1>Relatório de formas</h1>";
                case Italiano:
                    return "<h1>Forme rappoprto</h1>";
                default:
                    return "<h1>Shapes report</h1>";
            }
        }

        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | {TraducirArea(idioma)} {area:#.##} | {TraducirPerimetro(idioma)} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                        case Portugues:
                            return cantidad == 1 ? "Quadrado" : "Quadrados";
                        case Italiano:
                            return cantidad == 1 ? "Quadrato" : "Quadrati";
                        default:
                            return cantidad == 1 ? "Square" : "Squares";
                    }
                case Circulo:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Círculo" : "Círculos";
                        case Portugues:
                            return cantidad == 1 ? "Círculo" : "Círculos";
                        case Italiano:
                            return cantidad == 1 ? "Cerchio" : "Cerchi";
                        default:
                            return cantidad == 1 ? "Circle" : "Circles";
                    }
                case TrianguloEquilatero:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Triángulo" : "Triángulos";
                        case Portugues:
                            return cantidad == 1 ? "Triângulo" : "Triângulos";
                        case Italiano:
                            return cantidad == 1 ? "Triangolo" : "Triangoli";
                        default:
                            return cantidad == 1 ? "Triangle" : "Triangles";
                    }
                case Rectangulo:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                        case Portugues:
                            return cantidad == 1 ? "Retângulo" : "Retângulos";
                        case Italiano:
                            return cantidad == 1 ? "Rettangolo" : "Rettangoli";
                        default:
                            return cantidad == 1 ? "Rectangle" : "Rectangles";
                    }
                case Trapecio:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Trapecio" : "Trapecios";
                        case Portugues:
                            return cantidad == 1 ? "Trapecio" : "Trapecios";
                        case Italiano:
                            return cantidad == 1 ? "Trapezio" : "Trapezi";
                        default:
                            return cantidad == 1 ? "Trapeze" : "Trapezoids";
                    }
            }

            return string.Empty;
        }

        public static string TraducirArea(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return "Área";
                case Portugues:
                    return "Área";
                case Italiano:
                    return "Area";
                default:
                    return "Area";
            }
        }

        public static string TraducirPerimetro(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return "Perímetro";
                case Portugues:
                    return "Perímetro";
                case Italiano:
                    return "Perimetro";
                default:
                    return "Perimeter";
            }
        }

        public static string TraducirForma(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return "formas";
                case Portugues:
                    return "formas";
                case Italiano:
                    return "forme";
                default:
                    return "shapes";
            }
        }
    }
}
