using System;
using Converter.Generators;

namespace Converter
{
    internal static class Program
    {
        private const string JsonFileName = "output//database.json";
        private const string MarkdownFileName = "output//result.md";
        private const string DatabaseFileName = "source.accdb";

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