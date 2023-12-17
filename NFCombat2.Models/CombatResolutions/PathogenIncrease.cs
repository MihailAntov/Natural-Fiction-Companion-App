

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class PathogenIncrease : ICombatResolution
    {
        private Player.Player _player;
        private int _amount;
        public PathogenIncrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;

        }
        public MessageType MessageType => MessageType.PathogenIncrease;

        public string[] MessageArgs => new string[2] { _amount.ToString(), (_player.Pathogens + _amount).ToString() };

        public Task Resolve(Fight fight)
        {
            fight.Player.Pathogens+= _amount;
            return Task.CompletedTask;
        }
    }
}
