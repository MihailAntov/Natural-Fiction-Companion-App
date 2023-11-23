

namespace NFCombat2.Models.Contracts
{
    public interface IAddable
    {
        string Name { get; }
        bool IsInvention { get; set; }
        public int Id { get; set; }
    }
}
