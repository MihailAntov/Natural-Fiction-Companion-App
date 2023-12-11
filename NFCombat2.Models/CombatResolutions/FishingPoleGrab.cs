using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class FishingPoleGrab : ICombatResolution
    {
        private ItemMode _mode;
        private Enemy _enemy;
        public FishingPoleGrab(Enemy enemy, ItemMode mode)
        {
            _enemy = enemy;
            _mode = mode;
        }

        public MessageType MessageType => _mode == ItemMode.PoleMoveCloser ? MessageType.PoleMoveCloser : MessageType.PoleMoveFurther;

        public string[] MessageArgs => new string[1] { _enemy.Name };

        public Task Resolve(Fight fight)
        {
            switch (_mode)
            {
                case ItemMode.PoleMoveCloser:
                    _enemy.Distance -= 6;
                    break;
                case ItemMode.PoleMoveFuther:
                    _enemy.Distance += 6;
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
