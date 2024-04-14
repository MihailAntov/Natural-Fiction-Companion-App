using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Programs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class ProgramCastViewModel : INotifyPropertyChanged
    {
        private readonly TaskCompletionSource<ProgramExecution> _taskCompletionSource;
        private readonly IProgramService _programService;
        private readonly IPlayerService _playerService;
        public ProgramCastViewModel(TaskCompletionSource<ProgramExecution> taskCompletionSource, IProgramService programService, IPlayerService playerService)
        {
            _taskCompletionSource = taskCompletionSource;
            _programService = programService;
            _playerService = playerService;
            ExecuteProgramCommand = new Command(ExecuteProgram);
            ChangePolarityCommand = new Command<string>(ChangePolarity);
            OperationTypes = _programService.GetOperationTypes();
            SignalTypes = _programService.GetSignalTypes();
            ParadigmTypes = _programService.GetParadigmTypes();
            
        }

        public IList<ProgramFormulaComponent> OperationTypes { get; set; }
        public IList<ProgramFormulaComponent> SignalTypes { get; set; }
        public IList<ProgramFormulaComponent> ParadigmTypes { get; set; } 
        public Popup Popup { get; set; }

        public Command ExecuteProgramCommand { get; set; }
        public Command ChangePolarityCommand { get; set; }
        public void ChangePolarity(string component)
        {
            switch (component)
            {
                case "logicalOperation":
                    LogicalOperationPolarity = !LogicalOperationPolarity;
                    break;
                case "electricalSignal":
                    ElectricalSignalPolarity = !ElectricalSignalPolarity;
                    break;
                case "programParadigm":
                    ProgramParadigmPolarity = !ProgramParadigmPolarity;
                    break;
            }
        }
        
        public ProgramFormulaComponent LogicalOperationType { get; set; }
        private bool _logicalOperationPolarity = true;
        public bool LogicalOperationPolarity { get { return _logicalOperationPolarity; } set
            {
                if(_logicalOperationPolarity != value)
                {
                    _logicalOperationPolarity = value;
                    OnPropertyChanged(nameof(LogicalOperationPolarity));
                }
            }
        }

        public ProgramFormulaComponent ElectricalSignalType { get; set; }
        private bool _electricalSignalPolarity = true;
        public bool ElectricalSignalPolarity
        {
            get { return _electricalSignalPolarity; }
            set
            {
                if (_electricalSignalPolarity != value)
                {
                    _electricalSignalPolarity = value;
                    OnPropertyChanged(nameof(ElectricalSignalPolarity));
                }
            }
        }

        public ProgramFormulaComponent ProgramParadigmType { get; set; }
        private bool _programParadigmPolarity = true;

        public bool ProgramParadigmPolarity
        {
            get { return _programParadigmPolarity; }
            set
            {
                if (_programParadigmPolarity != value)
                {
                    _programParadigmPolarity = value;
                    OnPropertyChanged(nameof(ProgramParadigmPolarity));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(new ProgramExecution() { Result = ProgramExecutionResult.Cancelled});
        }

        public async void ExecuteProgram()
        {
            var program = _programService.GetProgram(BuildProgramFormula());
            if(program != null)
            {
                _programService.LearnNewProgram(program, _playerService.CurrentPlayer);
                _taskCompletionSource.TrySetResult(new ProgramExecution() { Result = ProgramExecutionResult.Success, Content = program});
                return;
            }
            else
            {
                _taskCompletionSource.TrySetResult(new ProgramExecution() { Result = ProgramExecutionResult.Fail });
            }
        }

        private string BuildProgramFormula()
        {
            LogicalOperationType.Positive = LogicalOperationPolarity;
            ElectricalSignalType.Positive = ElectricalSignalPolarity;
            ProgramParadigmType.Positive = ProgramParadigmPolarity;
            return $"{LogicalOperationType.Formula}{ElectricalSignalType.Formula}{ProgramParadigmType.Formula}";
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
