using System.IO;
using System.Text.Json;
using Converter.Model;

namespace Converter.Generators
{
    public class MarkdownFilesGenerator
    {
        public void GenerateMarkdownFileFromJson(string inputJsonFile, string outputMarkdownFile)
        {
            var container = JsonSerializer.Deserialize<Container>(File.ReadAllText(inputJsonFile));
            File.WriteAllText(outputMarkdownFile, container.GetMarkdownSection());
        }
    }
}