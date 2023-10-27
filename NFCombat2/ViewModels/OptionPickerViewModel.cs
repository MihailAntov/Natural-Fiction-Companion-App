using NFCombat2.Models.Contracts;
using NFCombat2.Services.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NFCombat2.ViewModels
{
    public class OptionPickerViewModel : INotifyPropertyChanged
    {
      
        private IOptionsService _optionsService;
        private IFightService _fightService;

        public OptionPickerViewModel(IOptionsService optionsService, IFightService fightService)
        {
            _optionsService = optionsService;
            _fightService = fightService;

            if (Categories == null)
            {
                Categories = new ObservableCollection<string>(_optionsService.GetCategories(_fightService.GetFight()));
            }

            OptionTapped = new Command(execute: (e)=> OptionClicked(e));

            
        }




        public ObservableCollection<IAction> Actions {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OptionTapped { get; private set;}

        private ObservableCollection<string> categories;
        public ObservableCollection<string> Categories { get { return categories; }
            set 
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public ObservableCollection<IAction> Options { get; set; }

        public async void OptionClicked(object e)
        {

            
            if (e is string category)
            {
                ICollection<IAction> options = new List<IAction>();
                var fight = _fightService.GetFight();
                switch (category)
                {
                    case "Programs":
                        options = _optionsService.GetPrograms(fight) as ICollection<IAction>;
                        break;
                    case "Shoot":
                    case "Attack":
                        break;
                    case "Item":
                        options = _optionsService.GetItems(fight) as ICollection<IAction>;
                        break;
                    case "Move in":
                        break;
                }
                Options = new ObservableCollection<IAction>(options);
            }


            //if (e is IStandardAction standardAction)
            //{
            //    standardAction.AffectFight(_fightService.GetFight());
            //}

            

           
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
