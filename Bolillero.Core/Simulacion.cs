using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero.Core
{
    public class Simulacion
    {
        public long SimularSinHilos(Bolillero bolillero, Jugada jugada, int cantidad)
        {
            long aciertos = 0;
            for (int i = 0; i < cantidad; i++)
            {
                if (bolillero.Jugar(jugada))
                {
                    aciertos++;
                }
                bolillero.ReiniciarBolillero();
            }
            return aciertos;
        }

        public long SimularConHilos(Bolillero bolillero, Jugada jugada, int total, int hilos)
        {
            long aciertos = 0;
            var tareas = new List<Task>();

            int porHilos = total / hilos;

            for (int i = 0; i < hilos; i++)
            {
                tareas.Add(Task.Run(() =>
                {
                    var copia = (Bolillero)bolillero.Clone();
                    long local = 0;

                    for (int j = 0; j < porHilos; j++)
                    {
                        if (copia.Jugar(jugada))
                        {
                            local++;
                        }
                        copia.ReiniciarBolillero();
                    }

                    lock (this)
                    {
                        aciertos += local;
                    }
                }));
            }

            Task.WaitAll(tareas.ToArray());
            return aciertos;
        }
    }
}
