using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_ExternalAPI_Test
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class JsonHelper
    {
        public Dictionary<string, string> FetchOneFieldPerDataType(string jsonString)
        {
            var result = new Dictionary<string, string>
        {
            { "string", string.Empty },
            { "int", string.Empty },
            { "boolean", string.Empty },
            { "datetime", string.Empty }
        };

            var jsonObject = JObject.Parse(jsonString);
            var keys = jsonObject.Descendants()
                .OfType<JProperty>()
                .Select(p => new { p.Name, p.Value })
                .ToList();

            foreach (var key in keys)
            {
                if (string.IsNullOrEmpty(result["string"]) && key.Value.Type == JTokenType.String)
                    result["string"] = key.Name;
                else if (string.IsNullOrEmpty(result["int"]) && key.Value.Type == JTokenType.Integer)
                    result["int"] = key.Name;
                else if (string.IsNullOrEmpty(result["boolean"]) && key.Value.Type == JTokenType.Boolean)
                    result["boolean"] = key.Name;
                else if (string.IsNullOrEmpty(result["datetime"]) && key.Value.Type == JTokenType.Date)
                    result["datetime"] = key.Name;

                // Stop if all fields are found
                if (!string.IsNullOrEmpty(result["string"]) && !string.IsNullOrEmpty(result["int"]) &&
                    !string.IsNullOrEmpty(result["boolean"]) && !string.IsNullOrEmpty(result["datetime"]))
                    break;
            }
            return result;
        }

        public string GetJsonValue(string jsonString, string key)
        {
            try
            {
                // Parse the JSON string into a JsonDocument  
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    // Access the root element  
                    JsonElement root = doc.RootElement;
                    // Check for "model" array in the JSON and iterate through it  
                    if (root.TryGetProperty("model", out JsonElement modelArray) && modelArray.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement element in modelArray.EnumerateArray())
                        {
                            // Try to get the value for the specified key  
                            if (element.TryGetProperty(key, out JsonElement valueElement))
                            {
                                return valueElement.ToString(); // Return the string representation of the value  
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Return null or empty string if the key is not found  
            return null;
        }


        public bool CompareJsonStrings(string json1, string json2)//, params string[] keysToRemove)
        {
            string[] keysToRemove = { };
            // Parse the JSON strings into JObject  
            JObject jsonObject1 = JObject.Parse(json1);
            JObject jsonObject2 = JObject.Parse(json2);
            jsonObject1.Remove("metaData");
            jsonObject2.Remove("metaData");

            var  compairResult= JToken.DeepEquals(jsonObject1, jsonObject2);
            string js1 = jsonObject1.ToString();
            string js2 = jsonObject2.ToString();

            // Compare the two modified JSON objects  
            return compairResult;
        }

        public bool DoesJsonExist(string jsonTarget, string json)
        {
            try
            {
                // Parse the JSON strings into JToken objects
                JToken token1 = JToken.Parse(jsonTarget);
                JToken token2 = JToken.Parse(json);

                var sss = token2.SelectToken(token1.Path);
                // Check if token1 exists in token2
                return token2.SelectToken(token1.Path) != null;
            }
            catch (JsonReaderException)
            {
                // Handle JSON parsing errors
                return false;
            }
        }
    }
}