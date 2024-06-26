﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class FreezeProgramEffect : IProgramEffect, ITarget
    {
        private int _turns;
        public FreezeProgramEffect(int turns, bool areaOfEffect = false, int minRange = 0, int maxRange = 10)
        {
            _turns = turns;
            AreaOfEffect = areaOfEffect;
            MinRange = minRange;
            MaxRange = maxRange;
        }
        public bool AreaOfEffect { get; set; }
        public string[] MessageArgs => Array.Empty<string>();
        public ICollection<Enemy> Targets { get; set; } = new HashSet<Enemy>();
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public MessageType MessageType => MessageType.ProgramFreezeMessage;

        public int Cost { get; set; } = 0;
        public bool BonusAction { get; set; }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var result = new List<ICombatResolution>();
            var freeze = new Freeze(_turns, Targets);
            fight.Effects.Enqueue(freeze);
            result.Add(freeze);
            fight.Player.Overload += Cost;
            if (BonusAction)
            {
                var bonus = new BonusAction();
                fight.Effects.Enqueue(bonus);
                result.Add(bonus);
            }
            return result;
        }

        public bool HasEffect(Fight fight)
        {
            return fight.Enemies.Any(e=> e.Distance >= MinRange && e.Distance <= MaxRange);
        }
    }
}
