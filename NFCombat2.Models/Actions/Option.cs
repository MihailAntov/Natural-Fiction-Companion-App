
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Actions
{
    public class Option : IOption
    {
        public Option(string label, object content)
        {
            Label = label;
            Content = content;
        }
        public string Label { get; set; }
        public object Content { get; set; }

        
    }
}
