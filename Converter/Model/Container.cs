using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace Converter.Model
{
    public class Container
    {
        public IEnumerable<Skill> Skills { get; set; }

        public static Container Of(IEnumerable<Skill> skills)
        {
            return new Container { Skills = skills };
        }

        public string GetMarkdownSection()
        {
            return string.Join(NewLine, Skills.Select(s => s.GetMarkdownSection()));
        }
    }
}