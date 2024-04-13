

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
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(3,false,1,10)
                    }
                }
            },
            {ProgramType.ReceiveNOptimizeNFix,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2,0,1,10,false,1,0,1)
                    },
                }
            },
            {ProgramType.ReceiveNOptimizeNAnalyze,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(2)
                    },
                }
            },
            {ProgramType.ReceiveNOptimizeFix,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2, 1)
                    },
                }
            },
            {ProgramType.ReceiveNExtendNFix,()=>new Program()//
                {
                    Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2,0,0,0,false,1,0,1)
                    },
                }
            },
            {ProgramType.ReceiveNDirectNMove,()=>new Program()//
                {Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2,true,1,10)
                    },
                }
            },
            {ProgramType.ReceiveNDirectNFix,()=>new Program()//
                {Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(1,3,1,10,true)
                    },
                }
            },
            {ProgramType.ReceiveDirectNMove,()=>new Program()//
                {Cost=1,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2,false,1,10)
                    },
                }
            },
            {ProgramType.ReceiveDirectNFix,()=>new Program()//
                {Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2,0,1,10,false)
                    },
                }
            },
            {ProgramType.ReceiveDirectNAnalyze,()=>new Program()//
                {
                    Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(1)
                    },
                }
            },
            {ProgramType.ReceiveDirectFix,()=>new Program()//
                {   
                    Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2,0),
                    },
                }
            },
            {ProgramType.ReceiveExtendNMove,()=>new Program()//
                {
                    Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2,false,11,1000)
                    },
                }
            },
            {ProgramType.ReceiveExtendNFix,()=>new Program()//
                {
                    Cost = 1,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(1,1,11,1000,false)
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNMove,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new FreezeProgramEffect(2,false,1,10),
                        new BonusActionProgramEffect()
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNFix,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new DamageProgramEffect(2,0,1,10,false),
                        new BonusActionProgramEffect()
                    },
                }
            },
            {ProgramType.ReceiveOptimizeNAnalyze,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new CritProgramEffect(1),
                        new BonusActionProgramEffect()
                    },
                }
            },
            {ProgramType.ReceiveOptimizeFix,()=>new Program()//
                {
                    Cost = 2,
                    Effects = new List<IProgramEffect>()
                    {
                        new HealProgramEffect(2,0),
                        new BonusActionProgramEffect()
                    },
                }
            },
            {ProgramType.SendDirectNUnlock,()=>new Program()
                {
                    Effects = new List<IProgramEffect>()
                    {
                        new TentacleDisableProgramEffect()
                    },
                }
            },
        };

    }
}
