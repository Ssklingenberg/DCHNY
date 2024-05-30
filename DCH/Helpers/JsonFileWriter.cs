using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using DCH.Models;

namespace DCH.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(Dictionary<int, Event> events, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(events,
                                                               Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonAc(Dictionary<int, Actor> actors, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(actors,
                                                               Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
