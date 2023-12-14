
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class CombatSuit : Equipment, IModifyPlayer, IModifyResolution
    {
        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is EnemyDealDamage dealDamage)
            {
                dealDamage.Damage -= 3;
            }

            if(resolution is TakeMeleeDamage meleeDamage)
            {
                meleeDamage.Amount -= 3;
            }
            return Task.FromResult(new List<ICombatAction>());
        }

        public void OnAdded(Player.Player player)
        {
            player.BonusStrength += 3;
            player.BonusMaxHealth += 10;
            OnPropertyChanged(nameof(player.Strength));
        }

        public void OnRemoved(Player.Player player)
        {
            player.BonusStrength -= 3;
            player.BonusMaxHealth -= 10;
            OnPropertyChanged(nameof(player.Strength));
        }
    }
}
