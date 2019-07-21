﻿/*
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
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

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

        public FormaGeometrica(decimal ancho)
        {
            _lado = ancho;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    //if (formas[i].Tipo == Cuadrado)
                    //{
                    formas[i].IncrementarCantidad();
                    areaCuadrados += formas[i].CalcularArea();
                    perimetroCuadrados += formas[i].CalcularPerimetro();
                    //}
                    //if (formas[i].Tipo == Circulo)
                    //{
                    //    numeroCirculos++;
                    //    areaCirculos += formas[i].CalcularArea();
                    //    perimetroCirculos += formas[i].CalcularPerimetro();
                    //}
                    //if (formas[i].Tipo == TrianguloEquilatero)
                    //{
                    //    numeroTriangulos++;
                    //    areaTriangulos += formas[i].CalcularArea();
                    //    perimetroTriangulos += formas[i].CalcularPerimetro();
                    //}
                }

                sb.Append(ObtenerLinea(
                    Classes.Cuadrado.GetCantidad(),
                    Classes.Cuadrado.GetTotalAreas(),
                    Classes.Cuadrado.GetTotalPerimetros(),
                    Cuadrado,
                    idioma));
                sb.Append(ObtenerLinea(
                    Classes.Circulo.GetCantidad(),
                    Classes.Circulo.GetTotalAreas(),
                    Classes.Circulo.GetTotalPerimetros(),
                    Circulo,
                    idioma));
                sb.Append(ObtenerLinea(
                    Classes.Triangulo.GetCantidad(),
                    Classes.Triangulo.GetTotalAreas(),
                    Classes.Triangulo.GetTotalPerimetros(), 
                    TrianguloEquilatero, 
                    idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(CantidadTotal + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append(
                    (idioma == Castellano ? "Perimetro " : "Perimeter ") + 
                    (PerimetrosTotal).ToString("#.##") +
                    " ");
                sb.Append("Area " + (AreasTotal).ToString("#.##"));
            }

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


        public static int GetCantidad()
        { return 0; }

        public static decimal GetTotalAreas()
        { return 0; }

        public static decimal GetTotalPerimetros()
        { return 0; }
    }
}
