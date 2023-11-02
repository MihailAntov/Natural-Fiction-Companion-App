

namespace NFCombat2.Models.Contracts
{
    public interface IOptionList
    {
        public ICollection<IOption> Options { get; set; }
        public bool IsInfoNeeded { get; set; }
    }
}
