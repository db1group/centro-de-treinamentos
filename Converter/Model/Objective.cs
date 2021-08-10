using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using static System.Environment;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Objective
    {
        [JsonIgnore] public int Id { get; set; }
        
        public string Name { get; set; }
        public string NameTrimmed => Name.Length <= 21 ? Name : Name[..21];
        public string ShortName => $"Nível 1: {NameTrimmed}";
        public int Level { get; set; }
        [JsonIgnore] public virtual int Track { get; set; }
        public virtual IList<Learnable> Learnables { get; set; }

        public string GetMarkdownSection()
        {
            var allLearnables = string.Join(NewLine, Learnables.Select(l => l.GetMarkdownSection()));
            return $"### Objetivo: {Name} (Nível {Level}){NewLine}{allLearnables}";
        }
    }
}