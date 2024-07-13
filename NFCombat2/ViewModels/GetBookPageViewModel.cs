using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NFCombat2.ViewModels
{
    public class GetBookPageViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string _before;
        public string Before
        {
            get { return _before; }
            set
            {
                if (_before != value)
                {
                    _before = value;
                    OnPropertyChanged(nameof(Before));
                }
            }
        }

        private string _after;
        public string After
        {
            get { return _after; }
            set
            {
                if (_after != value)
                {
                    _after = value;
                    OnPropertyChanged(nameof(After));
                }
            }
        }
        public GetBookPageViewModel(INameService nameService, ISettingsService settingsService) : base(nameService, settingsService)
        {
            UpdateLanguageSpecificProperties();
            TapCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
     
        public Command TapCommand { get; set; }
        public override void UpdateLanguageSpecificProperties()
        {
            Before = _nameService.Label(LabelType.GetBookBefore);
            After = _nameService.Label(LabelType.GetBookAfter);
            Title = _nameService.Label(LabelType.GetBookTitle);
        }
    }
}
