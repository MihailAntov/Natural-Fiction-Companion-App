using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class Program : IStandardAction, ITarget
    {
        public Program(string label, string description)
        {
            Label = label;
            Description = description;
        }
        public string Label { get; set; }
        public bool AreaOfEffect { get; set; }
        public bool BonusAction {  get; set; }
        public int Cost { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public ICollection<IProgramEffect> Effects { get; set; } = new List<IProgramEffect>();
        public ICollection<Enemy> Targets { get; set; } = new List<Enemy>();

        public string Description { get; set; }

        public MessageType MessageType => MessageType.UseProgramMessage;

        public string[] MessageArgs => new string[] { Label };

        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            foreach (var effect in Effects)
            {
                if(effect is ITarget targettingEffect)
                {
                    targettingEffect.Targets = Targets;
                }
                effect.AddToCombatEffects(fight);
            }

            return null;
        }



    }
}
