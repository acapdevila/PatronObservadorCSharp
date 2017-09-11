﻿using System;

namespace PatronObservador
{
    public class DispositivoEstadisticas
    {
        public void Actualizar(decimal temperatura, decimal presion, decimal humedad)
        {
            Console.WriteLine("Dispositivo estadísticas:");
            Console.WriteLine("Actualizando temperatura {0}, presión {1} y humedad {2}", temperatura, presion, humedad);
        }

        public void AñadirDatosParaLasEstadisticas(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;
        }
    }
}
