using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class ComboAttack : ICombatAction, IHaveRolls, ITarget
    {
        public ComboAttack(Enemy target)
        {
            RollsResult = DiceCalculator.Calculate(1);
            Targets = new List<Enemy>() { target };
        }
        public DiceRollResult RollsResult { get; set; }

        public DiceMessageType DiceMessageType => DiceMessageType.ComboDamageRoll;
        public int Amount { get; set; }
        public string DiceMessage { get; set; }
        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public MessageType MessageType => MessageType.ComboDamage;

        public virtual string[] MessageArgs => Array.Empty<string>();
        

        public ICollection<Enemy> Targets { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            var comboDamage = new DealComboDamage(Targets.FirstOrDefault(), RollsResult.FlatAmount + RollsResult.Dice.Sum(d => d.DiceValue));
            resolutions.Add(comboDamage);
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(1);
            return resolutions;
            
        }
    }
}
