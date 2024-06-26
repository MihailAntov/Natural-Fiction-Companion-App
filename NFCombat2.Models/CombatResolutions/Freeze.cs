﻿using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class Freeze : ICombatResolution
    {
        private int _turns;
        public Freeze(int turns, ICollection<Enemy> targets)
        {
            _turns = turns;
            Targets = targets;
        }
        public ICollection<Enemy> Targets { get; set; }
        public Enemy Target { get; set; }

        public MessageType MessageType
        {
            get
            {
                return Targets.Count == 1 ? MessageType.FreezeMessage : MessageType.FreezeAoeMessage;
            }
        }

        public string[] MessageArgs
        {
            get
            {
                return new string[] { Targets.Count > 1 ? Targets.Count.ToString() : Targets.FirstOrDefault().Name.ToString(), _turns.ToString() };
            }
        }

        public async Task Resolve(Fight fight)
        {
            foreach (var enemy in Targets)
            {
                enemy.RemainingFrozenTurns += _turns;
            }
        }
    }
}
