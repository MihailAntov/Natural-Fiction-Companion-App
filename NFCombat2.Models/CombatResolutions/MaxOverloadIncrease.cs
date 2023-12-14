

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class MaxOverloadIncrease : ICombatResolution
    {
        private Player.Player _player;
        private int _amount;
        public MaxOverloadIncrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.MaxOverloadIncrease;

        public string[] MessageArgs => new string[2] {_amount.ToString(),_player.MaxOverload.ToString() };

        public Task Resolve(Fight fight)
        {
            fight.Player.MaxOverload+= _amount;
            return Task.CompletedTask;
        }
    }
}
