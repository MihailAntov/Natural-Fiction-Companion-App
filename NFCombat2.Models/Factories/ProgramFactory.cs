

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
                return Programs[type];
            }
            return null;
            
        }
  

        private static Dictionary<ProgramType, Program> Programs = new Dictionary<ProgramType, Program>()
        {
            {ProgramType.ReceiveNOptimizeNMove,new Program() //
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNOptimizeNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNOptimizeNAnalyze,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNOptimizeFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNExtendNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNDirectNMove,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveNDirectNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveDirectNMove,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveDirectNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveDirectNAnalyze,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveDirectFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveExtendNMove,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveExtendNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveOptimizeNMove,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveOptimizeNFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveOptimizeNAnalyze,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.ReceiveOptimizeFix,new Program()//
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
            {ProgramType.SendDirectNUnlock,new Program()
                {
                    Effects = new List<IProgramEffect>()
                    {

                    },
                }
            },
        };

    }
}
