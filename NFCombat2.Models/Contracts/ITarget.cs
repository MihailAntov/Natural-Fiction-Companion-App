using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Contracts
{
    public interface ITarget
    {
        public ICollection<Enemy> Targets { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

    }
}
