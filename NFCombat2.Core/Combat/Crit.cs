﻿using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Combat
{
    public class Crit : IAffectCombat
    {
        private int _numberOfCrits;
        public Crit(int numberOfCrits)
        {
            _numberOfCrits = numberOfCrits;
        }
        public void AffectFight(Fight fight)
        {
            fight.RemainingCrits += _numberOfCrits;
        }
    }
}