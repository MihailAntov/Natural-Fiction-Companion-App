

using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Player;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DiceResultViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public ICollection<Dice> Dice { get; set; }
        public string Message { get; set; } 
        public Player Player { get; set; }
        public Command ConfirmCommand { get; set; }
        public Command RerollCommand { get; set; }
        public Command FreeRerollCommand { get; set; }
        private TaskCompletionSource<bool> _taskCompletionSource;
        public DiceResultViewModel(TaskCompletionSource<bool> task, Player player, INameService nameService) : base(nameService)
        {
            UpdateLanguageSpecificProperties();
            ConfirmCommand = new Command(ConfirmRolls);
            RerollCommand = new Command<Dice>(Reroll);
            FreeRerollCommand = new Command<Dice>(FreeReroll);
            _taskCompletionSource = task;
            Player = player;
        }
        public DiceResultViewModel(IHaveAttackRoll effect, Player player, TaskCompletionSource<bool> task, bool hasReroll, bool hasFreeReroll, INameService nameService) : this(task, player, nameService)
        {
            Dice = new List<Dice>() { effect.AttackRollResult };
            foreach(var die in Dice)
            {
                die.CanReroll = hasReroll;
                die.CanFreeReroll = hasFreeReroll;
            }
            Message = effect.AttackDiceMessage;
            
        }

        public DiceResultViewModel(IHaveRolls effect, Player player, TaskCompletionSource<bool> task,bool hasReroll, bool hasFreeReroll, INameService nameService) : this(task, player, nameService)
        {
            Dice = effect.RollsResult.Dice;
            foreach (var die in Dice)
            {
                die.CanReroll = hasReroll;
                die.CanFreeReroll = hasFreeReroll;
            }
            Message = effect.DiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
        }

        public DiceResultViewModel(DiceRollResult effect, string message, Player player, TaskCompletionSource<bool> task, bool hasReroll, bool hasFreeReroll, INameService nameService) : this(task, player, nameService)
        {
            Dice = effect.Dice;
            foreach (var die in Dice)
            {
                die.CanReroll = hasReroll;
                die.CanFreeReroll = hasFreeReroll;
            }
            Message = message;
            
        }

        private string _reRollButtonName;
        public string RerollButtonName
        {
            get { return _reRollButtonName; }
            set
            {
                if (_reRollButtonName != value)
                {
                    _reRollButtonName = value;
                    OnPropertyChanged(nameof(RerollButtonName));
                }
            }
        }

        private string _freeRerollButtonName;
        public string FreeRerollButtonName
        {
            get { return _freeRerollButtonName; }
            set
            {
                if (_freeRerollButtonName != value)
                {
                    _freeRerollButtonName = value;
                    OnPropertyChanged(nameof(FreeRerollButtonName));
                }
            }
        }

        private string _confirmButtonName;
        public string ConfirmButtonName
        {
            get { return _confirmButtonName; }
            set
            {
                if (_confirmButtonName != value)
                {
                    _confirmButtonName = value;
                    OnPropertyChanged(nameof(ConfirmButtonName));
                }
            }
        }

        private void ConfirmRolls()
        {
            _taskCompletionSource.SetResult(true);

        }

        public void Reroll(Dice dice)
        {
            dice.CanReroll = false;
            dice.Roll();
            Player.Health -= 4;
            OnPropertyChanged(nameof(dice.FileName));
        }

        public void FreeReroll(Dice dice)
        {
            dice.CanFreeReroll = false;
            dice.Roll();
            OnPropertyChanged(nameof(dice.FileName));
        }


        public override void UpdateLanguageSpecificProperties()
        {
            RerollButtonName = _nameService.Label(LabelType.RerollButton);
            FreeRerollButtonName = _nameService.Label(LabelType.FreeRerollButton);
            ConfirmButtonName = _nameService.Label(LabelType.ConfirmRoll);
        }
    }
}
