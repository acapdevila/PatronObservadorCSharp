using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObservador
{
    class Program
    {
        static void Main(string[] args)
        {
            EstacionMetereologica estacionMetereologica = new EstacionMetereologica();

            DispositivoTiempoActual dispositivoTiempoActual = new DispositivoTiempoActual();
            DispositivoEstadisticas dispositivoEstadisticas = new DispositivoEstadisticas();
            DispositivoPredictivo dispositivoPredictivo = new DispositivoPredictivo();
            
            estacionMetereologica.HaCambiadoElTiempo += dispositivoTiempoActual.ActualizarPantallaDipositivo;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoEstadisticas.AñadirDatosParaLasEstadisticas;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoPredictivo.AñadirDatosDePrediccion;

            estacionMetereologica.AumentarLaTemperaturaEnGrados(1);
            
            Console.ReadLine();

        }
    }
}
