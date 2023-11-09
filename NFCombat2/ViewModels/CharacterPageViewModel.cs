using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IProfileService _profileService;
        
        public Command RegisterCommand { get;  set; }
        public CharacterPageViewModel(IProfileService profileService)
        {
            _profileService = profileService;
            RegisterCommand = new Command<string>(async (name) => await RegisterProfile(name));
            
            
        }

        private string _characterName;
        public string CharacterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                if (_characterName != value)
                {
                    _characterName = value;
                    OnPropertyChanged(nameof(CharacterName));
                }
            }
        }

        public ObservableCollection<Player> Profiles => new ObservableCollection<Player>(GetAllProfiles());

        public async void ChangedClass()
        {
            //string name = (await _profileService.GetAll()).FirstOrDefault()?.Name;
        }

        public string ProfileName { get; set; }


        public async Task<bool> RegisterProfile(string name)
        {
            
            return await _profileService.Save(name);
            //await DisplayAlert("Successfully Added", $"{name}", "Okay");
        }

        public IList<Player> GetAllProfiles()
        {
            var profiles =  _profileService.GetAll();
            return profiles;
        }

        public async void ProcessChoice(object sender)
        {
            if(sender is Picker picker)
            {
                await SwitchToProfile((Player)picker.SelectedItem);
            }

            
        }
        public async Task SwitchToProfile(Player player)
        {
            await _profileService.SwitchActiveProfile(player);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
