using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Converter.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Learnable
    {
        [JsonIgnore] public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public int Objective { get; set; }
        public virtual IList<Content> Contents { get; set; }

        public string GetMarkdownSection()
        {
            return $"#### {Name}{Environment.NewLine}{string.Join(Environment.NewLine, GetFormattedContentList())}";
        }

        private IEnumerable<string> GetFormattedContentList()
        {
            return Contents.OrderBy(content => content.Order).Select(content => $"1. {content.GetMarkdownSection()}");
        }
    }
}