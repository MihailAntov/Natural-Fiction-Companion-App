using NFCombat2.Models.Fights;
using NFCombat2.Services.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class FightPageViewModel : INotifyPropertyChanged
    {

        private Fight fight;
        private IFightService _fightService;
        private IOptionsService _optionsService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command GetEpisodeCommand { get; }
        public Command ExitCombatCommand { get; }
        private string testLabel;
        public string TestLabel
        {
            get { return testLabel; }
            set
            {
                if(testLabel != value)
                {
                    testLabel = value;
                    OnPropertyChanged(nameof(TestLabel));
                }
            }
        }
        public string EpisodeNumber { get; set; }

        private bool notInCombat = true;
        public bool NotInCombat
        {
            get { return notInCombat; }
            set
            {
                if(notInCombat != value)
                {
                    notInCombat = value;
                    OnPropertyChanged(nameof(NotInCombat));
                }
            }
        } 

        public ObservableCollection<Enemy> Enemies { get; set; } = new ObservableCollection<Enemy>();
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<IAction> Options { get; set; } = new ObservableCollection<IAction>();
        public OptionPickerViewModel OptionPickerViewModel { get; set; } 

        

        public FightPageViewModel(IFightService fightService, IOptionsService optionsService, OptionPickerViewModel opctionPickerViewModel)
        {
                _fightService = fightService;
                _optionsService = optionsService;
            OptionPickerViewModel = opctionPickerViewModel;
            GetEpisodeCommand = new Command(GetEpisode);
            ExitCombatCommand = new Command(ExitCombat);
        }
        public async void GetEpisode()
        {
            int.TryParse(EpisodeNumber, out int episode);
            
            fight = await _fightService.GetFightByEpisodeNumber(episode);
            TestLabel = fight.GetType().Name;

            Enemies.Clear();
            foreach (var enemy in fight.Enemies)
            {
                Enemies.Add(enemy);
            }
            OptionPickerViewModel.Categories = new ObservableCollection<string>(_optionsService.GetCategories(fight));
            NotInCombat = false;
        }

        public async void ExitCombat()
        {
            NotInCombat = true;
            fight = null;
            Enemies.Clear();
            OptionPickerViewModel.Categories.Clear();
            OptionPickerViewModel.Targets.Clear();
            OptionPickerViewModel.Options.Clear();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
