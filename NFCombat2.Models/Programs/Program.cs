using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;

namespace NFCombat2.Models.Programs
{
    public class Program : IStandardAction, ITarget
    {
        private Player.Player _caster;
        public int Id { get; set; }
        public Program(string label, string description, Player.Player caster)
        {
            Label = label;
            Description = description;
            _caster = caster;
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

        public string[] MessageArgs => new string[] { Label, (Cost + _caster.Overload).ToString() };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            foreach (var effect in Effects)
            {
                if(effect is ITarget targettingEffect)
                {
                    targettingEffect.Targets = Targets;
                }
                resolutions.AddRange(effect.AddToCombatEffects(fight));
            }

            return resolutions;
        }



    }
}
