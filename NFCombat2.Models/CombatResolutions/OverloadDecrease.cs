

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class OverloadDecrease : ICombatResolution
    {
        private readonly Player.Player _player;
        private readonly int _amount;
        public OverloadDecrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.OverloadDecrease;

        public string[] MessageArgs => new string[2] {_amount.ToString(), _player.Overload.ToString() };

        public Task Resolve(Fight fight)
        {
            fight.Player.Overload-= _amount;
            return Task.CompletedTask;
        }
    }
}
