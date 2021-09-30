using System;
using Converter.Generators;

namespace Converter
{
    internal static class Program
    {
        private const string Assets = "../../../../Assets";
        private static readonly string DatabaseFileName = $"{Assets}/levelUpDevs.accdb";
        private static readonly string JsonFileName = $"{Assets}/Result/levelUpDevs.json";
        private static readonly string MarkdownFileName = $"{Assets}/Result/README.md";

        private static void Main()
        {
            ConvertFromDatabaseToJson();
            ConvertFromJsonToMarkdown();
            Console.WriteLine("Feito!");
        }

        private static void ConvertFromDatabaseToJson() =>
            JustDoIt("Gerando arquivo JSON a partir do banco de dados...",
                () => new JsonFilesGenerator().GenerateJsonFileFromDatabase(DatabaseFileName, JsonFileName));

        private static void ConvertFromJsonToMarkdown() =>
            JustDoIt("Gerando arquivo Markdown a partir do arquivo JSON...",
                () => new MarkdownFilesGenerator().GenerateMarkdownFileFromJson(JsonFileName, MarkdownFileName));

        private static void JustDoIt(string title, Action action)
        {
            try
            {
                Console.WriteLine(title);
                action.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ops, temos um problema: {e.Message}");
            }
        }
    }
}