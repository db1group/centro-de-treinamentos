using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using static System.Environment;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Competence
    {
        [JsonIgnore] public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Track> Tracks { get; set; }

        public string GetMarkdownSection()
        {
            return $"# Competência: {Name}{NewLine}{string.Join(NewLine, Tracks.Select(t => t.GetMarkdownSection()))}";
        }
    }
}