

using NFCombat2.Common.Enums;
using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class FreezeEffect : IProgramEffect, ITarget
    {
        private int _turns;
        public FreezeEffect(int turns, Program program)
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

        public void AffectFight(Fight fight)
        {

            fight.Effects.Enqueue(new Freeze(_turns, Targets));

        }

        
    }
}
