using Xunit;
using Bolillero;
namespace Bolillero.Core.Tests
{
    public class BolilleroTest
    {
        private Bolillero _bolillero;
        public BolilleroTest()
        {
            _bolillero = new Bolillero(10, new Primero());
        }

        [Fact]
        public void SacarBolilla()
        {
            var bolilla = _bolillero.SacarBolilla();
            
            Assert.Equal(0, bolilla.Numero);
            Assert.Equal(9, _bolillero.BolillasRestantes());
            Assert.Equal(1, _bolillero.CantidadBolillasExtraidas());
        }

        [Fact]
        public void ReIngresar()
        {
            _bolillero.SacarBolilla();
            _bolillero.ReiniciarBolillero();

            Assert.Equal(10, _bolillero.BolillasRestantes());
            Assert.Equal(0, _bolillero.CantidadBolillasExtraidas());
        }

        [Fact]
        public void JugarGana()
        {
            var jugada = new Jugada(new List<int> { 0, 1, 2 });
            var resultado = _bolillero.Jugar(jugada);
            Assert.True(resultado);
        }

        [Fact]
        public void JugarPierde()
        {
            var jugada = new Jugada(new List<int> { 0, 1, 10 });
            var resultado = _bolillero.Jugar(jugada);
            Assert.False(resultado);
        }

        [Fact]
        public void JugarNVeces()
        {
            var jugada = new Jugada(new List<int> { 0, 1, 2 });
            var resultado = _bolillero.JugarNVeces(jugada, 1);
            Assert.Equal(1, resultado);
        }
    }
}