

using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DiceResultViewModel : INotifyPropertyChanged
    {

        public ICollection<Dice> Dice { get; set; }
        private int _rerollsAvialable;
        public string Message { get; set; } 
        public bool CanReroll { get; set; }
        public Command ConfirmCommand { get; set; }
        public Command RerollCommand { get; set; }
        private TaskCompletionSource<bool> _taskCompletionSource;
        public DiceResultViewModel(IHaveAttackRoll effect, TaskCompletionSource<bool> task, bool canReroll, int reRollsAvailable)
        {
            Dice = new List<Dice>() { effect.AttackRollResult };
            Message = effect.AttackDiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
            RerollCommand = new Command<Dice>(Reroll);
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

        public void Reroll(Dice dice)
        {
            dice.Roll();
            OnPropertyChanged(nameof(dice.FileName));
        }


        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    }
}
