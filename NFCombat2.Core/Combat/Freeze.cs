﻿using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class Freeze : IAffectCombat , ITarget
    {
        private int _turns;
        public Freeze(int turns, ICollection<Enemy> targets)
        {
            _turns = turns;
            Targets = targets;
        }
        public ICollection<Enemy> Targets {get; set;}
        public void AffectFight(Fight fight)
        {
            foreach(var  enemy in Targets)
            {
                enemy.RemainingFrozenTurns += _turns;
            }
        }
    }
}