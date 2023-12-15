using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;


namespace NFCombat2.Models.CombatResolutions
{
    internal class TemporaryStrengthLoss : ICombatResolution
    {
        private int _amount;
        public TemporaryStrengthLoss(int amount)
        {
            _amount = amount;
        }
        public MessageType MessageType => MessageType.TemporaryStrengthDamage;

        public string[] MessageArgs => new string[1] { _amount.ToString() };

        public Task Resolve(Fight fight)
        {
           if(fight is SkillCheckFight skillCheck)
            {
                skillCheck.PlayerStrength -= _amount;
            }
           return Task.CompletedTask;
        }
    }
}
