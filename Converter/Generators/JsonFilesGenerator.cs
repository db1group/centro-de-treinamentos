using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Converter.Model;

namespace Converter.Generators
{
    public class JsonFilesGenerator
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
            {WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping};

        public void GenerateJsonFileFromDatabase(string databaseFileName, string jsonFileName)
        {
            var jsonContent = GetJsonContent(databaseFileName);
            WriteJsonToFile(jsonFileName, jsonContent);
        }

        private string GetJsonContent(string databaseFileName)
        {
            using var context = new Database(databaseFileName);
            return JsonSerializer.Serialize(Container.Of(context.Set<Competence>()), _jsonSerializerOptions);
        }

        private static void WriteJsonToFile(string fileName, string content)
        {
            var file = new FileInfo(fileName);
            file.Directory?.Create();
            File.WriteAllText(file.FullName, content);
        }
    }
}