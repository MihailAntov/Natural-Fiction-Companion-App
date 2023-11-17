using NFCombat2.Models.Items;

namespace NFCombat2.Models.Contracts
{
    public interface IInventoryActiveItem 
    {
        public abstract void AffectPlayer(Player.Player player);
    }
}
