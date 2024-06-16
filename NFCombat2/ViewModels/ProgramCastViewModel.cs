using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Programs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class ProgramCastViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly TaskCompletionSource<ProgramExecution> _taskCompletionSource;
        private readonly IProgramService _programService;
        private readonly IPlayerService _playerService;
        public ProgramCastViewModel(
            TaskCompletionSource<ProgramExecution> taskCompletionSource,
            IProgramService programService,
            IPlayerService playerService,
            INameService nameService) : base(nameService) 
        {
            _taskCompletionSource = taskCompletionSource;
            _programService = programService;
            _playerService = playerService;
            ExecuteProgramCommand = new Command(ExecuteProgram);
            ChangePolarityCommand = new Command<string>(ChangePolarity);
            CycleOperationCommand = new Command(CycleOperation);
            CycleSignalCommand = new Command(CycleSignal);
            CycleParadigmCommand = new Command(CycleParadigm);
            OperationTypes = _programService.GetOperationTypes();
            LogicalOperationType = OperationTypes.FirstOrDefault();
            SignalTypes = _programService.GetSignalTypes();
            ElectricalSignalType = SignalTypes.FirstOrDefault();
            ParadigmTypes = _programService.GetParadigmTypes();
            ProgramParadigmType = ParadigmTypes.FirstOrDefault();
            UpdateLanguageSpecificProperties();
        }

        public IList<ProgramFormulaComponent> OperationTypes { get; set; }
        public IList<ProgramFormulaComponent> SignalTypes { get; set; }
        public IList<ProgramFormulaComponent> ParadigmTypes { get; set; } 
        public Popup Popup { get; set; }

        public Command ExecuteProgramCommand { get; set; }
        public Command ChangePolarityCommand { get; set; }
        public Command CycleOperationCommand { get; set; }
        public Command CycleSignalCommand { get; set; }
        public Command CycleParadigmCommand { get; set; }
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

        public void CycleOperation()
        {
            int curInd = OperationTypes.IndexOf(LogicalOperationType);
            curInd = curInd == OperationTypes.Count - 1 ? 0 : curInd + 1;
            LogicalOperationType = OperationTypes[curInd];
        }

        public void CycleSignal()
        {
            int curInd = SignalTypes.IndexOf(ElectricalSignalType);
            curInd = curInd == SignalTypes.Count - 1 ? 0 : curInd + 1;
            ElectricalSignalType = SignalTypes[curInd];
        }

        public void CycleParadigm()
        {
            int curInd = ParadigmTypes.IndexOf(ProgramParadigmType);
            curInd = curInd == ParadigmTypes.Count - 1 ? 0 : curInd + 1;
            ProgramParadigmType = ParadigmTypes[curInd];
        }
        private ProgramFormulaComponent _logicalOperationType;
        public ProgramFormulaComponent LogicalOperationType { get { return _logicalOperationType; } set 
            {
                _logicalOperationType = value;
                OnPropertyChanged(nameof(LogicalOperationType));
            } 
        }

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

        private string _executeLabel;
        public string ExecuteLabel { get { return _executeLabel; } set
            {
                if( _executeLabel != value)
                {
                    _executeLabel = value; 
                    OnPropertyChanged(nameof(ExecuteLabel));
                }
            } 
        }
        private ProgramFormulaComponent _electricalSignalType;
        public ProgramFormulaComponent ElectricalSignalType { get { return _electricalSignalType; } set 
            {
                _electricalSignalType = value;
                OnPropertyChanged(nameof(ElectricalSignalType));
            }
        } 
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

        private ProgramFormulaComponent _programParadigmType;
        public ProgramFormulaComponent ProgramParadigmType { get { return _programParadigmType; } set 
            {
                _programParadigmType = value;
                OnPropertyChanged(nameof(ProgramParadigmType));
            } 
        } 
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

        public override void UpdateLanguageSpecificProperties()
        {
            ExecuteLabel = _nameService.Label(LabelType.ExecuteLabel);
        }
    }
}
