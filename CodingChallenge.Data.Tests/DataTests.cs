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
            var circulo = new List<FormaGeometrica> { new Circulo(5) };

            var resumen = FormaGeometrica.Imprimir(circulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Círculo | Area 19,63 | Perimetro 15,71 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perimetro 15,71 Area 19,63",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTriangulo()
        {
            var triangulo = new List<FormaGeometrica> { new Triangulo(5) };

            var resumen = FormaGeometrica.Imprimir(triangulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Triángulo | Area 10,83 | Perimetro 15 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perimetro 15 Area 10,83",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulo = new List<FormaGeometrica> { new Rectangulo(5, 8, FormaGeometrica.Rectangulo) };

            var resumen = FormaGeometrica.Imprimir(rectangulo, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1" +
                ">1 Rectángulo | Area 40 | Perimetro 26 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perimetro 26 Area 40",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "1 Cuadrado | Area 25 | Perimetro 20 <br/>" +
                "TOTAL:<br/>" +
                "1 formas Perimetro 20 Area 25",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
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
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Rectangulo(9, 7, FormaGeometrica.Rectangulo),
                new Triangulo(9),
                new Rectangulo(4, 12, FormaGeometrica.Rectangulo),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>" +
                "2 Squares | Area 29 | Perimeter 28 <br/>" +
                "2 Circles | Area 13,01 | Perimeter 18,06 <br/>" +
                "3 Triangles | Area 49,64 | Perimeter 51,6 <br/>" +
                "2 Rectangles | Area 111 | Perimeter 64 <br/>" +
                "TOTAL:<br/>" +
                "9 shapes Perimeter 161,66 Area 202,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Rectangulo(9, 7, FormaGeometrica.Rectangulo),
                new Triangulo(9),
                new Rectangulo(4, 12, FormaGeometrica.Rectangulo),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "2 Cuadrados | Area 29 | Perimetro 28 <br/>" +
                "2 Círculos | Area 13,01 | Perimetro 18,06 <br/>" +
                "3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>" +
                "2 Rectángulos | Area 111 | Perimetro 64 <br/>" +
                "TOTAL:<br/>" +
                "9 formas Perimetro 161,66 Area 202,65",
                resumen);
        }
    }
}
