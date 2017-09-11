using System;
namespace PatronObservador
{
    public class DispositivoPredictivo
    {
        public void Actualizar(decimal temperatura, decimal presion, decimal humedad)
        {
            Console.WriteLine("Dispositivo predictivo:");
            Console.WriteLine("Actualizando temperatura {0}, presión {1} y humedad {2}",temperatura, presion, humedad);
        }

        public void AñadirDatosDePrediccion(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;
        }
    }
}
