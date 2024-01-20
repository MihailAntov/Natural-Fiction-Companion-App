

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Programs;

namespace NFCombat2.Models.Factories
{
    public static class ProgramFactory
    {
        public static Program GetProgram(ProgramType programType)
        {
            Program program = new Program();
            switch(programType)
            {
                case ProgramType.ReceiveNOptimizeNMove:
                default:
                    break;
            }
            return program;
        }
        
    }
}
