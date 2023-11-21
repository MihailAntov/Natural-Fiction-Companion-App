

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class TakeMeleeDamage : ICombatResolution
    {
        private Player.Player _player;
        public TakeMeleeDamage(Player.Player player, int amount)
        {
            Amount = amount;
            _player = player;
        }
        public int Amount { get; set; }
        public MessageType MessageType => MessageType.TakeDamageMessage;

        public string[] MessageArgs => new string[] { Amount.ToString() };

        public Task Resolve(Fight fight)
        {
            _player.Health -= Amount;
            return Task.CompletedTask;
        }
    }
}
