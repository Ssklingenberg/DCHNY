using DCH.Models;

namespace DCH.Interfaces
{
    public interface IActorRepository //Indeholder interface-definitioner, som beskriver kontrakter for services. Defineres før services, så services kan implementere disse interfaces.
    {
        Dictionary<int, Actor> AllActors();
        Dictionary<int, Actor> FilterActors(string criteria);
        void DeleteActor(int id);
        void AddActor(Actor Actor);
        void UpdateActor(Actor Actor);
        Actor GetActors(int id);
        //Actor ActorLogin(string Email, string Password);
    }
}
