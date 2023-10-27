using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models
{
    public abstract class Item : IMoveAction
    {
        public abstract string Label { get; set; }

        public abstract void AffectFight(Fight fight);
    }
}
