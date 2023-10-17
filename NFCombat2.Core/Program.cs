using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models
{
    public abstract class Program : IStandardAction
    {
        public abstract string Label { get; }

        public abstract void AffectFight();

    }
}
