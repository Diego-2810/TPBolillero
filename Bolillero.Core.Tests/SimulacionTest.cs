using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Bolillero.Core.Tests
{
    public class SimulacionTest
    {
        [Fact]
        public void Clone_CrearCopiaIndependiente()
        {
            var bolillero = new Bolillero(10, new Primero());

            var copia = (Bolillero)bolillero.Clone();

            Assert.Equal(bolillero.BolillasRestantes(), copia.BolillasRestantes());

            copia.SacarBolilla();

            Assert.NotEqual(bolillero.BolillasRestantes(), copia.BolillasRestantes());
        }

        [Fact]
        public void SimularSinHilos_RealizarSimulacion()
        {
            var bolillero = new Bolillero(10, new Primero());
            var jugada = new Jugada(new List<int> { 0, 1 });

            var simulacion = new Simulacion();

            var aciertos = simulacion.SimularSinHilos(bolillero, jugada, 1);

            Assert.Equal(1, aciertos);
        }

        [Fact]
        public void SimularConHilos_RealizarSimulacion()
        {
            var bolillero = new Bolillero(10, new Primero());
            var jugada = new Jugada(new List<int> { 0, 1 });

            var simulacion = new Simulacion();

            var aciertos = simulacion.SimularConHilos(bolillero, jugada, 10, 2);

            Assert.Equal(10, aciertos);
        }
    }
}