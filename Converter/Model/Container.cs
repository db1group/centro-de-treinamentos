using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using static System.Environment;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Container
    {
        public IEnumerable<Competence> Competences { get; set; }

        public static Container Of(IEnumerable<Competence> competences)
        {
            return new Container { Competences = competences };
        }

        public string GetMarkdownSection()
        {
            return string.Join(NewLine, Competences.Select(s => s.GetMarkdownSection()));
        }
    }
}