using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using static System.Environment;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Track
    {
        [JsonIgnore] public int Id { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }
        [JsonIgnore] public int Skill { get; set; }
        public virtual IList<Objective> Objectives { get; set; }

        public string GetMarkdownSection()
        {
            return $"## Trilha: {Name}{NewLine}{string.Join(NewLine, Objectives.Select(o => o.GetMarkdownSection()))}";
        }
    }
}