﻿using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Programs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class ProgramCastViewModel : INotifyPropertyChanged
    {
        private readonly TaskCompletionSource<Program> _taskCompletionSource;
        private readonly IProgramService _programService;
        public ProgramCastViewModel(TaskCompletionSource<Program> taskCompletionSource, IProgramService programService)
        {
            _taskCompletionSource = taskCompletionSource;
            _programService = programService;
            ExecuteProgramCommand = new Command(ExecuteProgram);
            ChangePolarityCommand = new Command<string>(ChangePolarity);
            OperationTypes = _programService.GetOperationTypes();
            SignalTypes = _programService.GetSignalTypes();
            ParadigmTypes = _programService.GetParadigmTypes();
        }

        public IList<ProgramFormulaComponent> OperationTypes { get; set; }
        public IList<ProgramFormulaComponent> SignalTypes { get; set; }
        public IList<ProgramFormulaComponent> ParadigmTypes { get; set; } 

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
            _taskCompletionSource.TrySetResult(null);
        }

        public void ExecuteProgram()
        {

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}