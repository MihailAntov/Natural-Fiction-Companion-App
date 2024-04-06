

using NFCombat2.Common.Enums;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;

namespace NFCombat2.Contracts
{
    public interface IProgramService
    {
        public Program GetProgram(ProgramType programType);
        public ProgramType? GetProgramType(string programString);

        public void GetKnownPrograms(Player player);

        public void LearnNewProgram(Player player, Program program);
        public IList<ProgramFormulaComponent> GetOperationTypes();
        public IList<ProgramFormulaComponent> GetSignalTypes();
        public IList<ProgramFormulaComponent> GetParadigmTypes();

    }
}
