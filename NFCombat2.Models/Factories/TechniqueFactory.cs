using NFCombat2.Models.SpecOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Factories
{
    public static class TechniqueFactory
    {
        public static Dictionary<int, List<Technique>> TechniqueChoices = new Dictionary<int, List<Technique>>()
        {
            {
                30, new List<Technique>()
                {
                    new Backflip(),
                    new Sprint()
                }
            },
            {
                25, new List<Technique>()
                {
                    new Anticipation(),
                    new Feint()
                }
            },
            {
                20, new List<Technique>()
                {
                    new Brace(),
                    new DoubleGrip()
                }
            },
            {
                15, new List<Technique>()
                {
                    new Resilience(),
                    new FightingSpirit()
                }
            },
            {
                10, new List<Technique>()
                {
                    new PrimalInstinct(),
                    new Combo()
                }
            },
            {
                5, new List<Technique>()
                {
                    new BattleMastery(),
                    new IronWill()
                }
            },
            {
                1, new List<Technique>()
                {
                    new Perfectionism(),
                    new DeadlyStrike()
                }
            },
        };
    }
}
