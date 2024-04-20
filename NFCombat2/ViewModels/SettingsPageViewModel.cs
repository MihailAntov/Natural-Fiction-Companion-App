using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.ViewModels
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {
        private readonly ISettingsService _settingsService;
        public SettingsPageViewModel(ISettingsService settingsService)
        {
           _settingsService = settingsService;
            GetDefaultLanguage();
        }

        private bool _bgChosen;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool BGChosen { get { return _bgChosen; }  }
        public void GetDefaultLanguage()
        {
            var lang = _settingsService.Language;
            if(lang == Language.Bulgarian)
            {
                _bgChosen = true;
                return;
            }
            _bgChosen = false;
            
        }

        public void ChooseLanguage(string language, bool isChecked)
        {
            if (isChecked)
            {
                switch(language)
                {
                    case "bg":
                        _settingsService.SetLanguage(Common.Enums.Language.Bulgarian);
                        break;
                    case "en":
                        _settingsService.SetLanguage(Common.Enums.Language.English);
                        break;
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
