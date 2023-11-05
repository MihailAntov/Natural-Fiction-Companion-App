using NFCombat2.Helpers;
using NFCombat2.Services.Contracts;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DicePageViewModel : INotifyPropertyChanged
    {
        
        public DicePageViewModel()
        {
            DiceCollection = new List<Dice>();
            
            for (int i = 0; i < 10; i++)
            {
                var nextDice = new Dice(6,$"dice{i}");
                DiceCollection.Add(nextDice);
            }
        }
        private int numberOfDice = 1;

        public int NumberOfDice
        {
            get { return numberOfDice; }
            set
            {
                if (numberOfDice != value && value > 0 && value <= 10)
                {
                    numberOfDice = value;
                    OnPropertyChanged(nameof(NumberOfDice));
                }
            }
        }

        private int bonusDamage = 0;

        public int BonusDamage
        {
            get { return bonusDamage; }
            set
            {
                if (bonusDamage != value && value > 0)
                {
                    bonusDamage = value;
                    OnPropertyChanged(nameof(BonusDamage));
                }
            }
        }
        

        public List<Dice> DiceCollection { get; set; }

        public int Result { get; set; } = 0;

        public bool ResultVisible { get; set; } = false;

        public Random random;

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Roll()
        {
            for (int i = 0; i < 10; i++)
            {
                DiceCollection[i].IsVisible = false;
            }

            ResultVisible = true;

            for (int i = 0; i < NumberOfDice; i++)
            {
                var currentDice = DiceCollection[i];
                currentDice.Roll();
                currentDice.FileName = $"dice{currentDice.DiceValue}";
                currentDice.IsVisible = true;
                OnPropertyChanged(nameof(currentDice.IsVisible));
                OnPropertyChanged(nameof(DiceCollection));
                OnPropertyChanged(nameof(currentDice.FileName));
                
                
            }

            

            

            
            Result = DiceCollection.Take(NumberOfDice).Sum(d=> d.DiceValue) + BonusDamage;

            OnPropertyChanged(nameof(ResultVisible));
            OnPropertyChanged(nameof(Result));
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
