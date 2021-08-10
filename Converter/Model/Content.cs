using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Content
    {
        private Dictionary<string, string> _translations = new Dictionary<string, string>
            { { "Course", "Curso" }, { "Read", "Leitura" }, { "Tip", "Dica" }, { "Watch", "Áudio/Vídeo" } };

        private const string GoogleUrl = "https://www.google.com/search?q=";

        [JsonIgnore] public int Id { get; set; }
        [JsonIgnore] public int Learnable { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public int? Order { get; set; }
        private string GoogleIt => $"{GoogleUrl}{Uri.EscapeUriString(Description)}";
        private string WorkingLink => LinkIsEmpty ? GoogleIt : Link;
        private bool LinkIsEmpty => string.IsNullOrEmpty(Link);
        private bool IsJustTip => Type == "Tip" && LinkIsEmpty;
        public string GetMarkdownSection() => IsJustTip ? $"{FormattedDescr}" : $"[{FormattedDescr}]({WorkingLink})";
        private string FormattedDescr => $"{TypeTranslated}{Description}";
        private string TypeSanitized => Type ?? "Tip";

        private string TypeTranslated =>
            _translations.ContainsKey(TypeSanitized) ? $"[{_translations[TypeSanitized]}] " : string.Empty;
    }
}