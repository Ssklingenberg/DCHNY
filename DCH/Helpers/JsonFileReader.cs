using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using DCH.Models;

namespace DCH.Helpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, Event> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Event>>(jsonString);
        }

        public static Dictionary<int, Actor> ReadJsonAc(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Actor>>(jsonString);
        }

    }
}
