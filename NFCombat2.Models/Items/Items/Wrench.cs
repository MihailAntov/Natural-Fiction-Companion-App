using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Wrench : Item, ICombatActiveItem, ITarget, IHaveRolls
    {
        public Wrench()
        {
            Name = "Wrench";
            IsConsumable = true;
            RollsResult = DiceCalculator.Calculate(1);
        }

        public MessageType MessageType => MessageType.WrenchThrow;

        public string[] MessageArgs => new string[] { Targets.FirstOrDefault().Name };

        public bool UnavailableForRestOfCombat { get; set; }
        public ICollection<Enemy> Targets { get; set; } = new List<Enemy>();
        public bool AreaOfEffect { get; set; } = false;
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 5;
        public DiceRollResult RollsResult { get; set; }

        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.WrenchRoll;

        public string[] DiceMessageArgs { get; set; } = Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var damage = new DealDamage(RollsResult, Targets);
            fight.Effects.Enqueue(damage);
            return new List<ICombatResolution>() { damage }; 
        }
    }
}
