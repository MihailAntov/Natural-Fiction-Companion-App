using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Contracts;
using NFCombat2.Models.Dice;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DicePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        
        public DicePageViewModel(INameService nameService) : base(nameService)
        {
            UpdateLanguageSpecificProperties();
            DiceCollection = new List<Dice>();
            
            for (int i = 0; i < 25; i++)
            {
                var nextDice = new Dice(6);
                DiceCollection.Add(nextDice);
            }
        }
        private int numberOfDice = 1;

        public int NumberOfDice
        {
            get { return numberOfDice; }
            set
            {
                if (numberOfDice != value && value > 0 && value <= 25)
                {
                    numberOfDice = value;
                    OnPropertyChanged(nameof(NumberOfDice));
                }
            }
        }
        private string _rollButtonName;
        public string RollButtonName { get { return _rollButtonName; } set
            {
                if(_rollButtonName != value)
                {
                    _rollButtonName = value;
                    OnPropertyChanged(nameof(RollButtonName));
                }
            } 
        }


        private int bonusDamage = 0;

        public int BonusDamage
        {
            get { return bonusDamage; }
            set
            {
                if (bonusDamage != value && value >= 0)
                {
                    bonusDamage = value;
                    OnPropertyChanged(nameof(BonusDamage));
                }
            }
        }
        

        public List<Dice> DiceCollection { get; set; }

        public string Result { get; set; } 

        private string _resultFormat;
        public string ResultFormat { get { return _resultFormat; } set
            {
                if(_resultFormat != value)
                {
                    _resultFormat = value;
                    OnPropertyChanged(nameof(ResultFormat));
                }
            } 
        }

        public bool ResultVisible { get; set; } = false;

        public Random random;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Roll()
        {
            for (int i = 0; i < 25; i++)
            {
                DiceCollection[i].IsVisible = false;
            }

            ResultVisible = true;

            for (int i = 0; i < NumberOfDice; i++)
            {
                var currentDice = DiceCollection[i];
                currentDice.Roll();
                currentDice.IsVisible = true;
                OnPropertyChanged(nameof(currentDice.IsVisible));
                OnPropertyChanged(nameof(DiceCollection));
                OnPropertyChanged(nameof(currentDice.FileName));
                
                
            }

            

            

            int resultVal = DiceCollection.Take(NumberOfDice).Sum(d => d.DiceValue) + BonusDamage;
            Result = String.Format(ResultFormat, resultVal);

            OnPropertyChanged(nameof(ResultVisible));
            OnPropertyChanged(nameof(Result));
        }



        public override void UpdateLanguageSpecificProperties()
        {
            RollButtonName = _nameService.Label(LabelType.RollButton);
            ResultFormat = _nameService.Label(LabelType.RollResultFormat);
            if (ResultVisible)
            {
                int resultVal = DiceCollection.Take(NumberOfDice).Sum(d => d.DiceValue) + BonusDamage;
                Result = String.Format(ResultFormat, resultVal);
                OnPropertyChanged(nameof(Result));

            }
            
        }
    }
}
