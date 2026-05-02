using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero.Core;

public class Jugada
{
    public List<int> Numeros { get; }
    public Jugada(List<int> numeros)
    {
        Numeros = numeros;
    }
}
