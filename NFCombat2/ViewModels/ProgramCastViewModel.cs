using NFCombat2.Common.Enums;
using NFCombat2.Models.Programs;

namespace NFCombat2.ViewModels
{
    public class ProgramCastViewModel
    {
        private readonly TaskCompletionSource<Program> _taskCompletionSource;
        public ProgramCastViewModel(TaskCompletionSource<Program> taskCompletionSource)
        {
            _taskCompletionSource = taskCompletionSource;
        }

        public List<ProgramComponentType> OperationTypes { get; set; } = new List<ProgramComponentType>()
        {
            ProgramComponentType.Receive, ProgramComponentType.Send
        };
        public List<ProgramComponentType> SignalTypes { get; set; } = new List<ProgramComponentType>
        {
            ProgramComponentType.Direct, ProgramComponentType.Extend, ProgramComponentType.Optimize
        };
        public List<ProgramComponentType> ParadigmTypes { get; set; } = new List<ProgramComponentType> 
        {
            ProgramComponentType.Analyze, ProgramComponentType.Unlock, ProgramComponentType.Fix, ProgramComponentType.Move        
        };
        
        public ProgramFormulaComponent LogicalOperationType { get; set; }

        public ProgramFormulaComponent ElectricSignalType { get; set; }

        public ProgramFormulaComponent ProgramParadigmType { get; set; }

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(null);
        }
    }
}
