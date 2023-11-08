using NFCombat2.Contracts;


using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CharacterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IProfileService _profileService;
        

        public CharacterPageViewModel(IProfileService profileService) : base()
        {
            _profileService = profileService;
        }

        private string _characterName;
        public string CharacterName
        {
            get { 
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

        public async void ChangedClass()
        {
            string name = (await _profileService.GetAll()).FirstOrDefault()?.Name;
        }

        public string ProfileName { get; set; }


        public async void RegisterProfile()
        {
            string name = ProfileName;
            _profileService.Save(name);
            //await DisplayAlert("Successfully Added", $"{name}", "Okay");
        }

        public async void GetAllProfiles()
        {
            var profiles = await _profileService.GetAll();
            string result = string.Join(",", profiles.Select(x => $"{x.Name}, HP:{x.Health}"));
            //await DisplayAlert("profiles", result, "Okay");
        }

        public async void SwitchToProfile(int profileId)
        {

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
