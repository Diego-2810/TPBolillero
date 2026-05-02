using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero.Core;

public class GeneradorRandom : IGeneradorAleatorio
{
    private Random _random = new Random();
    public int Generar(int min, int max)
    {
        return _random.Next(min, max );
    }
}
