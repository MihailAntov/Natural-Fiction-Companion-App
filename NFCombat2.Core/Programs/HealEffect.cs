

using NFCombat2.Common.Enums;
using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class HealEffect : IProgramEffect
    {
        private int _dice;
        private int _delayedDice;
        public HealEffect(int dice, int delayedDice)
        {
            _dice = dice;
            _delayedDice = delayedDice;
        }
        public string[] MessageArgs => Array.Empty<string>();
        public MessageType MessageType => MessageType.ProgramHealMessage;

        public void AffectFight(Fight fight)
        {
            fight.Effects.Enqueue(new Heal(_dice, _delayedDice));
        }

        
    }
}
