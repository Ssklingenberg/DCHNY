using DCH.Interfaces;
using DCH.Models;
using DCH.Helpers;
using Microsoft.Extensions.Logging;

namespace DCH.Services
{
    public class ActorJson : IActorRepository
    {
        //string JsonFileName = @"C:\Users\papri\OneDrive - Zealand\Skrivebord\Projekt 1. sem\DcH\DCH\Data\JsonActors.json";
        //string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonActors.json";
        //string JsonFileName = @"C:\Users\mlber\source\repos\DCH\DCH\Data\JsonActors.json";
        //string JsonFileName = @"C:\Users\sskli\source\repos\DCH\DCH\Data\JsonActors.json";

        private readonly Dictionary<int, Actor> actors = new Dictionary<int, Actor>();
        private int currentId = 0;

        public ActorJson()
        {
            actors = AllActors();

            if (actors.Keys.Any())
            {
                currentId = actors.Keys.Max() + 1;
            }
            else
            {
                currentId = 0;
            }
        }

        public void AddActor(Actor ac)
        {
            {
                if (ac != null)
                {
                    ac.Id = currentId++;
                }
                actors[ac.Id] = ac;
                JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
            }
        }

        public void AddActorIdNo(Actor ac)
            {
                ac.Id = currentId++;

            }

        

        public Dictionary<int, Actor> AllActors()
        {
            return JsonFileReader.ReadJsonAc(JsonFileName);
        }

        public void DeleteActor(int id)
        { 
            Dictionary<int, Actor> actors = AllActors();
            actors.Remove(id);
            JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
        }

        //public Dictionary<int, Actor> FilterActors(string criteria)
        //{
        //    Dictionary<int, Actor> Actor = AllActors();
        //    Dictionary<int, Actor> myActors = new Dictionary<int, Actor>();
        //    if (criteria != null)
        //    {
        //        foreach (var a in Actor.Values)
        //        {
        //            if (a.FirstName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
        //                a.LastName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
        //                a.Email.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
        //                a.City.Contains(criteria, StringComparison.OrdinalIgnoreCase))
        //            {
        //                myActors.Add(a.Id, a);
        //            }
        //        }
        //    }
        //    return myActors;
        //}

        //Method that can also handle Ints
        public Dictionary<int, Actor> FilterActors(string criteria)
        {
            Dictionary<int, Actor> Actors = AllActors();
            Dictionary<int, Actor> filteredActors = new Dictionary<int, Actor>();

            if (criteria != null)
            {
                // Try to parse the criteria as an int for ID and PhoneNumber comparison
                bool isNumericCriteria = int.TryParse(criteria, out int numericCriteria);

                foreach (var a in Actors.Values)
                {
                    // Check string properties
                    bool matchesStringCriteria = a.FirstName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                                                 a.LastName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                                                 a.Email.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                                                 a.City.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                                                 a.PhoneNumber.Contains(criteria, StringComparison.OrdinalIgnoreCase);

                    // Check numeric properties if the criteria is numeric
                    bool matchesNumericCriteria = isNumericCriteria &&
                                                  (a.Id == numericCriteria);// = || a.PhoneNumber == numericCriteria ;

                    if (matchesStringCriteria || matchesNumericCriteria)
                    {
                        filteredActors.Add(a.Id, a);
                    }
                }
            }

            return filteredActors;
        }

        public Actor GetActors(int id)
        {
            Dictionary<int, Actor> actors = AllActors();
            return actors[id];
        }

        public void UpdateActor(Actor Actor)
        {
            Dictionary<int, Actor> actors = AllActors();
            if (Actor != null)
            {
                actors[(int)Actor.Id] = Actor;
            }
            JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
        }
    }
}
