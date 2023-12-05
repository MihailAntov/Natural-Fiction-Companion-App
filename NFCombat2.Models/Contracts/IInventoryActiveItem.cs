using NFCombat2.Common.Enums;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Contracts
{
    public interface IInventoryActiveItem 
    {
        public abstract ICombatResolution AffectPlayer(Player.Player player);
        public int Quantity { get; set; }
    }
}
