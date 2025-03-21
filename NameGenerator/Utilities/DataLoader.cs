using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NameGenerator.Models;

namespace NameGenerator.Utilities
{
    public static class DataLoader
    {
        public static NameData LoadNameData()
        {
            // Get the current assembly.
            var assembly = Assembly.GetExecutingAssembly();

            // The resource name must match your project namespace and folder structure.
            // For example, if your project is "NameGenerator" and the JSON file is in the "Data" folder:
            string resourceName = "NameGenerator.Data.namesData.json";  

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException("Embedded resource not found: " + resourceName);

                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<NameData>(json);
                }
            }
        }
    }
}

