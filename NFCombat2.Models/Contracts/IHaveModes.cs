

namespace NFCombat2.Models.Contracts
{
    public interface IHaveModes
    {
        public IList<IMode> Modes { get; set; }
        public IMode Mode { get; set; }
    }
}
