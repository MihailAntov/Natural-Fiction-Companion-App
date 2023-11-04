

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Actions
{
    public class OptionList : IOptionList
    {
        public OptionList()
        {
            
        }

        public OptionList(ICollection<IOption> options, bool isInfoNeeded, bool canGoBack)
        {
            Options = options;
            IsInfoNeeded = isInfoNeeded;
            CanGoBack = canGoBack;

        }
        public ICollection<IOption> Options { get; set; } = new HashSet<IOption>();
        public bool IsInfoNeeded { get; set; } = false;
        public bool CanGoBack { get; set; }
        public string Label { get; set; }

    }
}
