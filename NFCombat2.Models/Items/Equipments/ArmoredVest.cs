

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class ArmoredVest : Equipment, IModifyPlayer
    {
        public ArmoredVest()
        {

        }


        public void OnAdded(Player.Player player)
        {
            player.BonusMaxHealth += 5;
            OnPropertyChanged(nameof(player.Strength));
        }

        public void OnRemoved(Player.Player player)
        {
            player.BonusMaxHealth -= 5;

            if(player.Health > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
            OnPropertyChanged(nameof(player.Strength));
        }
    }
}
