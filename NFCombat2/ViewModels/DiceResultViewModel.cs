

using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using System.ComponentModel;

namespace NFCombat2.ViewModels
{
    public class DiceResultViewModel : INotifyPropertyChanged
    {

        public ICollection<Dice> Dice { get; set; }
        private int _rerollsAvialable;
        public string Message { get; set; } 
        public bool CanReroll { get; set; }
        public Command ConfirmCommand { get; set; }
        private TaskCompletionSource<bool> _taskCompletionSource;
        public DiceResultViewModel(IHaveAttackRoll effect, TaskCompletionSource<bool> task, bool canReroll, int reRollsAvailable)
        {
            Dice = new List<Dice>() { effect.AttackRollResult };
            Message = effect.AttackDiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
            _taskCompletionSource = task;
            CanReroll = canReroll;
            _rerollsAvialable = reRollsAvailable;
        }

        public DiceResultViewModel(IHaveRolls effect, TaskCompletionSource<bool> task, bool canReroll, int reRollsAvailable)
        {
            Dice = effect.RollsResult.Dice;
            Message = effect.DiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
            _taskCompletionSource = task;
            CanReroll = canReroll;
            _rerollsAvialable = reRollsAvailable;
        }

        public DiceResultViewModel(DiceRollResult effect, string message, TaskCompletionSource<bool> task, bool canReroll, int reRollsAvailable)
        {
            Dice = effect.Dice;
            Message = message;
            ConfirmCommand = new Command(ConfirmRolls);
            _taskCompletionSource = task;
            CanReroll = canReroll;
            _rerollsAvialable = reRollsAvailable;
        }

        private void ConfirmRolls()
        {
            _taskCompletionSource.SetResult(true);

        }


        

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
