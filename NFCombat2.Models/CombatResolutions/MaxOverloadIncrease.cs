

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class MaxOverloadIncrease : ICombatResolution
    {
        private Player.Player _player;
        public MaxOverloadIncrease(Player.Player player)
        {
            _player = player;
        }
        public MessageType MessageType => MessageType.MaxOverloadIncrease;

        public string[] MessageArgs => new string[1] {(_player.MaxOverload).ToString() };

        public Task Resolve(Fight fight)
        {
            fight.Player.MaxOverload++;
            return Task.CompletedTask;
        }
    }
}
