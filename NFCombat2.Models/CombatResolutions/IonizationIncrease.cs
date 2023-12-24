

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class IonizationIncrease : ICombatResolution
    {
        private Player.Player _player;
        private int _amount;
        public IonizationIncrease(Player.Player player, int amount)
        {
            _player = player;

            _amount = amount;

        }
        public MessageType MessageType => MessageType.IonizationIncrease;

        public string[] MessageArgs => new string[2] { _amount.ToString(), (_player.Ionization+_amount).ToString() };

        public Task Resolve(Fight fight)
        {
            fight.Player.Ionization++;
            return Task.CompletedTask;
        }
    }
}
