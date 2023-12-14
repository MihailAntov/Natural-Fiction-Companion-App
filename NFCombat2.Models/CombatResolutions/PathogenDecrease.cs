

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class PathogenDecrease : ICombatResolution
    {
        private readonly Player.Player _player;
        private readonly int _amount;
        public PathogenDecrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.PathogenDecrease;

        public string[] MessageArgs => new string[2] {_amount.ToString(),_player.Pathogens.ToString()};

        public Task Resolve(Fight fight)
        {
            fight.Player.Pathogens-= _amount;
            return Task.CompletedTask;
        }
    }
}
