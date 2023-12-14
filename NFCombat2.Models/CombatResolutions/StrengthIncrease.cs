

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class StrengthIncrease : ICombatResolution
    {
        private readonly Player.Player _player;
        private readonly int _amount;
        public StrengthIncrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.StrengthIncrease;

        public string[] MessageArgs => new string[1] {_amount.ToString()};

        public Task Resolve(Fight fight)
        {
            fight.Player.BonusStrength += _amount;
            fight.TemporaryEffects.Add(()=> fight.Player.BonusStrength -= _amount);
            return Task.CompletedTask;
        }
    }
}
