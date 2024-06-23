using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Contracts;
using NFCombat2.Models.Dice;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class DicePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly Random _random;
        public DicePageViewModel(INameService nameService) : base(nameService)
        {
            UpdateLanguageSpecificProperties();
            DiceCollection = new List<Dice>();
            RollCommand = new Command(async () => await Roll());
            _random = new Random();
            for (int i = 0; i < 25; i++)
            {
                var nextDice = new Dice(6);
                nextDice.Roll();
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

        private int _ones;
        public int Ones { get { return _ones; } set
            {
                if(_ones!= value)
                {
                    _ones = value;
                    OnPropertyChanged(nameof(Ones));
                }
            } 
        }

        private int _twos;
        public int Twos
        {
            get { return _twos; }
            set
            {
                if (_twos != value)
                {
                    _twos = value;
                    OnPropertyChanged(nameof(Twos));
                }
            }
        }

        private int _threes;
        public int Threes
        {
            get { return _threes; }
            set
            {
                if (_threes != value)
                {
                    _threes = value;
                    OnPropertyChanged(nameof(Threes));
                }
            }
        }

        private int _fours;
        public int Fours
        {
            get { return _fours; }
            set
            {
                if (_fours != value)
                {
                    _fours = value;
                    OnPropertyChanged(nameof(Fours));
                }
            }
        }

        private int _fives;
        public int Fives
        {
            get { return _fives; }
            set
            {
                if (_fives != value)
                {
                    _fives = value;
                    OnPropertyChanged(nameof(Fives));
                }
            }
        }

        private int _sixes;
        public int Sixes
        {
            get { return _sixes; }
            set
            {
                if (_sixes != value)
                {
                    _sixes = value;
                    OnPropertyChanged(nameof(Sixes));
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
        
        public Command RollCommand { get; set; }



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


        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public async Task Roll()
        {

            Task task = new Task (()=>
            {
                int _ones = 0;
                int _twos = 0;
                int _threes = 0;
                int _fours = 0;
                int _fives = 0;
                int _sixes = 0;

                Dice currentDice = null;

                ResultVisible = true;

                for (int i = 0; i < NumberOfDice; i++)
                {
                    currentDice = DiceCollection[i];
                    currentDice.Roll();
                    switch (currentDice.DiceValue)
                    {
                        case 1:
                            _ones++;
                            break;
                        case 2:
                            _twos++;
                            break;
                        case 3:
                            _threes++;
                            break;
                        case 4:
                            _fours++;
                            break;
                        case 5:
                            _fives++;
                            break;
                        case 6:
                            _sixes++;
                            break;
                        default:
                            break;

                    }   
                }

                Ones = _ones;
                Twos = _twos; 
                Threes = _threes;
                Fours = _fours;
                Fives = _fives;
                Sixes = _sixes;

                int resultVal = DiceCollection.Take(NumberOfDice).Sum(d => d.DiceValue) + BonusDamage;
                Result = String.Format(ResultFormat, resultVal);

                OnPropertyChanged(nameof(ResultVisible));
                OnPropertyChanged(nameof(Result));
            });
            task.Start();
            await task;
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
