using System;

namespace PatronObservador
{
    public class DispositivoTiempoActual
    {
        public void Actualizar(decimal temperatura, decimal presion, decimal humedad)
        {
            Console.WriteLine("Dispositivo tiempo actual:");
            Console.WriteLine("Actualizando temperatura {0}, presión {1} y humedad {2}", temperatura, presion, humedad);
        }

        public void ActualizarPantallaDipositivo(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;
        }
    }

    public class DispositivoTiempoActualObservador : IObservador
    {
        private readonly EstacionMetereologicaVersion2 _estacionMetereologica;
        public DispositivoTiempoActualObservador(EstacionMetereologicaVersion2 estacionMetereologica)
        {
            _estacionMetereologica = estacionMetereologica;
        }

        public void Actualizar()
        {
            // ... código

            // Cuando me vaya bien, llamo al publicador para conocer las medidas
            var temperatura = _estacionMetereologica.Temperatura;
            var presion = _estacionMetereologica.Presion;
            var humedad = _estacionMetereologica.Humedad;

            // ... código
        }
    }
}
