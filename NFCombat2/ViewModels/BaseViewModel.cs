

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected INameService _nameService;
        protected readonly ISettingsService _settingsService;
        public BaseViewModel(INameService nameSerivce, ISettingsService settingsService)
        {
            _nameService = nameSerivce;
            _settingsService = settingsService;
            _nameService.PropertyChanged += OnLanguagePropertyChanged;
            _settingsService.PropertyChanged += OnLanguagePropertyChanged;
            UpdateLanguageSpecificProperties();
            
            ChangeLanguageCommand = new Command(async () => await ChangeLanguage());
            
        }
        public Command ChangeLanguageCommand { get; set; }
        public string LanguageIcon => _settingsService.LanguageIcon;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnLanguagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_nameService.Language))
            {
                UpdateLanguageSpecificProperties();
            }
            OnPropertyChanged(nameof(LanguageIcon));
        }


        public async Task ChangeLanguage()
        {
            if (_settingsService.Language == Language.Bulgarian)
            {
                await _settingsService.SetLanguage(Language.English);
                return;
            }

            await _settingsService.SetLanguage(Language.Bulgarian);
        }

        public abstract void UpdateLanguageSpecificProperties();
        

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
