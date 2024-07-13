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
    public class SettingsPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly ISettingsService _settingsService;
        public SettingsPageViewModel(ISettingsService settingsService,INameService nameService) :base(nameService, settingsService)
        {
           _settingsService = settingsService;
            GetDefaultLanguage();
        }

        private bool _bgChosen;

        private string _languageLabel;
        public string LanguageLabel
        {
            get { return _languageLabel; }
            set
            {
                if(_languageLabel != value)
                {
                    _languageLabel = value;
                    OnPropertyChanged(nameof(LanguageLabel));
                }
            }
        }
        //public event PropertyChangedEventHandler PropertyChanged;

        public bool BGChosen { get { return _bgChosen; } private set 
            {
                if(_bgChosen != value )
                {
                    _bgChosen = value;
                    OnPropertyChanged(nameof(BGChosen));
                }
            } 
        }
        public void GetDefaultLanguage()
        {
            var lang = _settingsService.Language;
            if(lang == Language.Bulgarian)
            {
                _bgChosen = true;
                return;
            }
            _bgChosen = false;
            OnPropertyChanged(nameof(BGChosen));
            
        }

        public void ChooseLanguage(string language, bool isChecked)
        {
            if (isChecked)
            {
                switch(language)
                {
                    case "bg":
                        _settingsService.SetLanguage(Common.Enums.Language.Bulgarian);
                        BGChosen = true;
                        break;
                    case "en":
                        _settingsService.SetLanguage(Common.Enums.Language.English);
                        BGChosen = false;
                        break;
                }
            }
        }

        public override void UpdateLanguageSpecificProperties()
        {
            LanguageLabel = _nameService.Label(LabelType.Language);
        }



        //public void OnPropertyChanged([CallerMemberName] string name = "") =>
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
