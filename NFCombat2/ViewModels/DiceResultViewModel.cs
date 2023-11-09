

using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using System.ComponentModel;

namespace NFCombat2.ViewModels
{
    public class DiceResultViewModel : INotifyPropertyChanged
    {

        public ICollection<Dice> Dice { get; set; }
        public string Message { get; set; } 
        public Command ConfirmCommand { get; set; }
        private TaskCompletionSource<bool> _taskCompletionSource;
        public DiceResultViewModel(IHaveAttackRoll effect, TaskCompletionSource<bool> task)
        {
            Dice = new List<Dice>() { effect.AttackRollResult };
            Message = effect.AttackDiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
            _taskCompletionSource = task;
        }

        public DiceResultViewModel(IHaveRolls effect, TaskCompletionSource<bool> task)
        {
            Dice = effect.RollsResult.Dice;
            Message = effect.DiceMessage;
            ConfirmCommand = new Command(ConfirmRolls);
            _taskCompletionSource = task;
        }

        private void ConfirmRolls()
        {
            _taskCompletionSource.SetResult(true);

        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
