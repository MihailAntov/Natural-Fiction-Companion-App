

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class FreezeProgramEffect : IProgramEffect, ITarget
    {
        private int _turns;
        public FreezeProgramEffect(int turns, Program program)
        {
                _turns = turns;
            AreaOfEffect = program.AreaOfEffect;
            MinRange = program.MinRange;
            MaxRange = program.MaxRange;
        }
        public bool AreaOfEffect { get; set; }
        public string[] MessageArgs => Array.Empty<string>();
        public ICollection<Enemy> Targets { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType => MessageType.ProgramFreezeMessage;

        public ICombatResolution AddToCombatEffects(Fight fight)
        {
            var freeze = new Freeze(_turns, Targets);
            fight.Effects.Enqueue(freeze);
            return freeze;
        }

        
    }
}
