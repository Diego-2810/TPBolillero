using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero.Core;

public class Bolillero
{
    private readonly List<Bolilla> _bolillas;
    private readonly List<Bolilla> _bolillasExtraidas;
    private readonly IGeneradorAleatorio _generador;
    public Bolillero(int cantidad, IGeneradorAleatorio generador)
    {
        _generador = generador;
        _bolillas = new List<Bolilla>();
        _bolillasExtraidas = new List<Bolilla>();

        for (int i = 0; i < cantidad; i++)
        {
            _bolillas.Add(new Bolilla(i));
        }
    }

    public Bolilla SacarBolilla()
    {
        if (_bolillas.Count == 0)
            return null;

        int indice = _generador.Generar(0, _bolillas.Count);
        var bolillaExtraida = _bolillas[indice];
        _bolillas.RemoveAt(indice);
        _bolillasExtraidas.Add(bolillaExtraida);
        return bolillaExtraida;
    }

    public bool Jugar(Jugada jugada)
    {
        foreach (var numero in jugada.Numeros)
        {
            var bolilla = SacarBolilla();

            if (bolilla == null || bolilla.Numero != numero)
            {
                return false;
            }
        }
        return true;
    }

    public int JugarNVeces (Jugada jugada, int cantidadVeces)
    {
        int aciertos = 0;
        for (int i = 0; i < cantidadVeces; i++)
        {
            if (Jugar(jugada))
            {
                aciertos++;
            }
            ReiniciarBolillero();
        }
        return aciertos;
    }

    public void ReiniciarBolillero()
    {
        _bolillas.AddRange(_bolillasExtraidas);
        _bolillasExtraidas.Clear();
    }

    public int BolillasRestantes()
    {
        return _bolillas.Count;
    }

    public int CantidadBolillasExtraidas()
    {
        return _bolillasExtraidas.Count;
    }
    
}
