

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Programs;

namespace NFCombat2.Models.Factories
{
    public static class ProgramFactory
    {

        public static Program GetProgram(ProgramType type)
        {
            if(Programs.ContainsKey(type))
            {
                var creatorFunc = Programs[type];
                return creatorFunc();
            }
            return null;
            
        }


        private static Dictionary<ProgramType, Func<Program>> Programs = new Dictionary<ProgramType, Func<Program>>()
        {
            {ProgramType.ReceiveNOptimizeNMove,()=>new Program() //
                {

                    Formula = ProgramType.ReceiveNOptimizeNMove.ToString(),
                    Effects = new List<IProgramEffect>()
                    {

                        new FreezeProgramEffect(3, false, 1, 10)
                        {
                            Cost = 2,
                        }
                    }
                }
            },
            {ProgramType.ReceiveNOptimizeNFix,()=>new Program()//
                {

                    Formula = ProgramType.ReceiveNOptimizeNFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2, 0, DiceMessageType.ProgramDamageRoll)
                        {
                            Cost = 2,
                            MinRange = 1,
                            MaxRange = 10,
                            DelayedDuration = 1,
                            DelayedNumberOfDice = 1,
                            DelayedFlatDamage = 0,
                            DelayedDiceMessageType = DiceMessageType.DelayedProgramDamageRoll
                        }
                    },
                }
            },
            {ProgramType.ReceiveNOptimizeNAnalyze,()=>new Program()//
                {

                    Formula = ProgramType.ReceiveNOptimizeNAnalyze.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(2)
                        {
                            Cost = 2,
                        }
                    },
                }
            },
            {ProgramType.ReceiveNOptimizeFix,()=>new Program()//
                {

                    Formula = ProgramType.ReceiveNOptimizeFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2, DiceMessageType.ProgramHealingRoll)
                        {
                            Cost = 2,
                            DelayedDice = 1
                            
                        }
                    },
                }
            },
            {ProgramType.ReceiveNExtendNFix,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveNExtendNFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2,-1,DiceMessageType.ProgramDamageRoll)
                        {
                            Cost = 1,
                            MinRange = 0,
                            MaxRange = 0
                        }
                    },
                }
            },
            {ProgramType.ReceiveNDirectNMove,()=>new Program()//
                {
                Formula = ProgramType.ReceiveNDirectNMove.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2, true, 1, 10)
                        {
                            Cost = 1,
                        }
                    },
                }
            },
            {ProgramType.ReceiveNDirectNFix,()=>new Program()//
                {
                Formula = ProgramType.ReceiveNDirectNFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(1, 3, DiceMessageType.ProgramDamageRoll)
                        {
                            Cost = 1,
                            AreaOfEffect = true,
                            MinRange = 1,
                            MaxRange = 10
                        }
                    },
                }
            },
            {ProgramType.ReceiveDirectNMove,()=>new Program()//
                {
                Formula = ProgramType.ReceiveDirectNMove.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2, false, 1, 10)
                        {
                            Cost=1,
                        }
                    },
                }
            },
            {ProgramType.ReceiveDirectNFix,()=>new Program()//
                {
                Formula = ProgramType.ReceiveDirectNFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2, 0, DiceMessageType.ProgramDamageRoll)
                        {
                            Cost = 1,
                            MinRange = 1,
                            MaxRange = 10
                        }
                    },
                }
            },
            {ProgramType.ReceiveDirectNAnalyze,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveDirectNAnalyze.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(1)
                        {
                            Cost = 1,
                        }
                    },
                }
            },
            {ProgramType.ReceiveDirectFix,()=>new Program()//
                {   
                    
                    Formula = ProgramType.ReceiveDirectFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2, DiceMessageType.ProgramHealingRoll)
                        {
                            Cost = 1,
                        }
                    },
                }
            },
            {ProgramType.ReceiveExtendNMove,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveExtendNMove.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2, false, 11, 1000)
                        {
                            Cost = 1,
                        }
                    },
                }
            },
            {ProgramType.ReceiveExtendNFix,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveExtendNFix.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(1, 1, DiceMessageType.ProgramDamageRoll)
                        {
                            Cost = 1,
                            MinRange = 11, 
                            MaxRange = 1000
                        }
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNMove,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveOptimizeNMove.ToString(),
                    BonusAction = true,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2, false, 1, 10)
                        {
                            BonusAction = true,
                            Cost = 2,
                        }
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNFix,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveOptimizeNFix.ToString(),
                    BonusAction = true,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2, 0, DiceMessageType.ProgramDamageRoll)
                        {
                            BonusAction = true,
                            Cost = 2,
                            MinRange = 1,
                            MaxRange = 10
                        }
                        
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNAnalyze,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveOptimizeNAnalyze.ToString(),
                    BonusAction = true,
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(1)
                        {
                            BonusAction = true,
                            Cost = 2,
                        }
                    },
                }
            },
            {ProgramType.ReceiveOptimizeFix,()=>new Program()//
                {
                    
                    Formula = ProgramType.ReceiveOptimizeFix.ToString(),
                    BonusAction = true,
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2, DiceMessageType.ProgramHealingRoll)
                        {
                            BonusAction = true,
                            Cost = 2,
                        }
                    },
                }
            },
            {ProgramType.SendDirectNUnlock,()=>new Program()
                {   
                    
                    Formula = ProgramType.SendDirectNUnlock.ToString(),
                    Effects = new List<IProgramEffect>()
                    {
                        new TentacleDisableProgramEffect()
                        {
                            Cost = 1,
                        }
                    },
                }
            },
        };

    }
}
