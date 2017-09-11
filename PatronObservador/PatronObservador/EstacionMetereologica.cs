using System;
using System.Collections.Generic;

namespace PatronObservador
{
    public class EstacionMetereologicaVersion1
    {
        public decimal Temperatura { get;  }
        public decimal Presion { get;  }
        public decimal Humedad { get;  }


        private readonly DispositivoTiempoActual _dispositivoTiempoActual;
        private readonly DispositivoEstadisticas _dispositivoEstadisticas;
        private readonly DispositivoPredictivo _dispositivoPredictivo;
        // ... siguientes dispositivos
        
        public EstacionMetereologicaVersion1(
                DispositivoTiempoActual dispositivoTiempoActual, 
                DispositivoEstadisticas dispositivoEstadisticas, 
                DispositivoPredictivo dispositivoPredictivo
                // ... siguientes dispositivos
            )
        {
            _dispositivoTiempoActual = dispositivoTiempoActual;
            _dispositivoEstadisticas = dispositivoEstadisticas;
            _dispositivoPredictivo = dispositivoPredictivo;
            // ... siguientes dispositivos
        }

        public void HaCambiadoElTiempo()
        {
            _dispositivoTiempoActual.Actualizar(Temperatura, Presion, Humedad);
            _dispositivoEstadisticas.Actualizar(Temperatura, Presion, Humedad);
            _dispositivoPredictivo.Actualizar(Temperatura, Presion, Humedad);
            // ... siguientes dispositivos
        }
    }


    // Utilizando el patrón Observer
    public class EstacionMetereologicaVersion2 : IPublicador
    {
        public decimal Temperatura { get; }
        public decimal Presion { get; }
        public decimal Humedad { get; }

        private readonly List<IObservador> _observadores; 
        
        public EstacionMetereologicaVersion2(List<IObservador> observadores)
        {
            _observadores = observadores;
         }

        public void HaCambiadoElTiempo()
        {
           Notificar();
        }

        public void Notificar()
        {
            foreach (var observador in _observadores)
            {
                observador.Actualizar();
            }
        }

        public void RegistrarObservador(IObservador observador)
        {
            _observadores.Add(observador);
        }

        public void QuitarObservador(IObservador observador)
        {
            _observadores.Remove(observador);
        }
    }
    


    public class EstacionMetereologica
    {
        public event EventHandler<Tuple<decimal, decimal, decimal>> HaCambiadoElTiempo;

        public decimal Temperatura { get; private set; }
        public decimal Presion { get; private set; }
        public decimal Humedad { get; private set; }

       public void AumentarLaTemperaturaEnGrados(int grados)
        {
            Temperatura = grados + 1;

            Notificar();
        }

        public void Notificar()
        {

            var medidas = new Tuple<decimal, decimal, decimal>(Temperatura, Humedad, Presion);

            if (HaCambiadoElTiempo != null)
                HaCambiadoElTiempo.Invoke(this, medidas);
        }
    }
}
