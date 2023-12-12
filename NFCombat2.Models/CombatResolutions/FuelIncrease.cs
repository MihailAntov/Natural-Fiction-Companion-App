using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class FuelIncrease : ICombatResolution
    {
        private Player.Player _player;
        private int _amount;
        public FuelIncrease(Player.Player player, int amount)
        {
            _player = player;
            _amount = amount;
        }
        public MessageType MessageType => MessageType.FuelIncrease;

        public string[] MessageArgs => new string[2] {_amount.ToString(), _player.Fuel.ToString()};

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
