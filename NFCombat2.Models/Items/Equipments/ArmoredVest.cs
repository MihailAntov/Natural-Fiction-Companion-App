

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class ArmoredVest : Equipment, IModifyPlayer
    {
        public ArmoredVest()
        {
            BonusHealth = 5;
            HasBonusBag = false;
        }
        public int BonusHealth { get; set; }
        public bool HasBonusBag { get; set; }

        public void OnAdded(Player.Player player)
        {
            player.BonusMaxHealth += 5;
        }

        public void OnRemoved(Player.Player player)
        {
            player.BonusMaxHealth -= 5;
            if(player.Health > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
        }
    }
}
