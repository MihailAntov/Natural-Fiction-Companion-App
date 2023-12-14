using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Contracts
{
    public interface ICombatActiveItem :  IMoveAction
    {
        public bool UnavailableForRestOfCombat { get; set; }
        public bool IsConsumable { get; }
        public int Quantity { get; set; }
    }
}
