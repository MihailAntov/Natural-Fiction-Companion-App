

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Actions
{
    public class OptionList : IOptionList
    {
        public OptionList()
        {
            
        }

        public OptionList(ICollection<IOption> options, bool isInfoNeeded)
        {
            Options = options;
            IsInfoNeeded = isInfoNeeded;
        }
        public ICollection<IOption> Options { get; set; } = new HashSet<IOption>();
        public bool IsInfoNeeded { get; set; } = false;

    }
}
