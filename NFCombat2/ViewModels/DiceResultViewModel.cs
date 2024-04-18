

using NFCombat2.Common.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Dice;
using NFCombat2.Models.Player;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DiceResultViewModel : INotifyPropertyChanged
    {

        public ICollection<Dice> Dice { get; set; }
        public string Message { get; set; } 
        public Player Player { get; set; }
        public Command ConfirmCommand { get; set; }
        public Command RerollCommand { get; set; }
        public Command FreeRerollCommand { get; set; }
        private TaskCompletionSource<bool> _taskCompletionSource;
        public DiceResultViewModel(TaskCompletionSource<bool> task, Player player)
        {
            ConfirmCommand = new Command(ConfirmRolls);
            RerollCommand = new Command<Dice>(Reroll);
            FreeRerollCommand = new Command<Dice>(FreeReroll);
            _taskCompletionSource = task;
            Player = player;
        }
        public DiceResultViewModel(IHaveAttackRoll effect, Player player, TaskCompletionSource<bool> task, bool hasReroll, bool hasFreeReroll) : this(task, player)
        {
            Dice = new List<Dice>() { effect.AttackRollResult };
            foreach(var die in Dice)
            {
                die.CanReroll = hasReroll;
                die.CanFreeReroll = hasFreeReroll;
            }
            Message = effect.AttackDiceMessage;
            
        }

        public DiceResultViewModel(IHaveRolls effect, Player player, TaskCompletionSource<bool> task,bool hasReroll, bool hasFreeReroll) : this(task, player)
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

        public DiceResultViewModel(DiceRollResult effect, string message, Player player, TaskCompletionSource<bool> task, bool hasReroll, bool hasFreeReroll) : this(task, player)
        {
            Dice = effect.Dice;
            foreach (var die in Dice)
            {
                die.CanReroll = hasReroll;
                die.CanFreeReroll = hasFreeReroll;
            }
            Message = message;
            
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




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    }
}
