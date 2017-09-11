namespace PatronObservador
{
   public interface IPublicador
   {
       void RegistrarObservador(IObservador observador);
       void QuitarObservador(IObservador observador);

       void Notificar();
   }
}
