using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCirculo()
        {
            var circulo = new List<FormaGeometrica> { new Circle(5) };

            var resumen = FormaGeometrica.Imprimir(circulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Círculo | Área 19,63 | Perímetro 15,71 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perímetro 15,71 Área 19,63",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCirculoEnItaliano()
        {
            var circulo = new List<FormaGeometrica> { new Circle(5) };

            var resumen = FormaGeometrica.Imprimir(circulo, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Forme rappoprto</h1>" +
                "1 Cerchio | Area 19,63 | Perimetro 15,71 <br/>" +
                "TOTAL:<br/>" +
                "1 forme Perimetro 15,71 Area 19,63",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTriangulo()
        {
            var triangulo = new List<FormaGeometrica> { new Triangle(5) };

            var resumen = FormaGeometrica.Imprimir(triangulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Triángulo | Área 10,83 | Perímetro 15 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perímetro 15 Área 10,83",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTriangulosEnPortugues()
        {
            var triangulo = new List<FormaGeometrica>
            {
                new Triangle(5),
                new Triangle(11),
                new Triangle(8),
            };

            var resumen = FormaGeometrica.Imprimir(triangulo, FormaGeometrica.Portugues);

            Assert.AreEqual(
                "<h1>Relatório de formas</h1>" +
                "3 Triângulos | Área 90,93 | Perímetro 72 <br/>" +
                "TOTAL:<br/>" +
                "3 formas Perímetro 72 Área 90,93",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulo = new List<FormaGeometrica> { new Rectangle(5, 8) };

            var resumen = FormaGeometrica.Imprimir(rectangulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1" +
                ">1 Rectángulo | Área 40 | Perímetro 26 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perímetro 26 Área 40",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Square(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Cuadrado | Área 25 | Perímetro 20 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perímetro 20 Área 25",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Trapezoid(7, 13, 5, 5, 4),
                new Rectangle(9, 7),
                new Triangle(9),
                new Rectangle(4, 12),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>" +
                "2 Squares | Area 29 | Perimeter 28 <br/>" +
                "2 Circles | Area 13,01 | Perimeter 18,06 <br/>" +
                "3 Triangles | Area 49,64 | Perimeter 51,6 <br/>" +
                "2 Rectangles | Area 111 | Perimeter 64 <br/>" +
                "1 Trapeze | Area 40 | Perimeter 30 <br/>" +
                "TOTAL:<br/>" +
                "10 shapes Perimeter 191,66 Area 242,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Trapezoid(7, 13, 5, 5, 4),
                new Rectangle(9, 7),
                new Triangle(9),
                new Rectangle(4, 12),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "2 Cuadrados | Área 29 | Perímetro 28 <br/>" +
                "2 Círculos | Área 13,01 | Perímetro 18,06 <br/>" +
                "3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>" +
                "2 Rectángulos | Área 111 | Perímetro 64 <br/>" +
                "1 Trapecio | Área 40 | Perímetro 30 <br/>" +
                "TOTAL:<br/>" +
                "10 formas Perímetro 191,66 Área 242,65",

                resumen);
        }
    }
}
