using CommunityToolkit.Maui.Views;
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
    public class HandChoiceViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly TaskCompletionSource<Hand> _taskCompletionSource;
        public HandChoiceViewModel(TaskCompletionSource<Hand> taskCompletionSource, INameService nameService, ISettingsService settingsService) : base(nameService, settingsService)
        {
            _taskCompletionSource = taskCompletionSource;
            UpdateLanguageSpecificProperties();
            ChooseHandCommand = new Command<string>(async (s)=> await ChooseHand(s));
        }
        private string _mainHandName;
        public Popup Popup { get; set; }
        public Command ChooseHandCommand { get; set; }

        public async Task ChooseHand(string hand)
        {
            _taskCompletionSource.TrySetResult(hand == "main" ? Hand.MainHand : Hand.OffHand);
            await Popup.CloseAsync();
        }

        public void Cancel()
        {
            _taskCompletionSource.TrySetResult(Hand.None);
        }

        public override void UpdateLanguageSpecificProperties()
        {
            MainHandName = _nameService.HandName(Hand.MainHand);
            OffHandName = _nameService.HandName(Hand.OffHand);
        }

        public string MainHandName
        {
            get { return _mainHandName; }
            set
            {
                if(_mainHandName != value )
                {
                    _mainHandName = value;
                    OnPropertyChanged(nameof(MainHandName));
                }
            }
        }
        private string _offHandName;
        public string OffHandName { get { return _offHandName; } set 
            { 
                if(_offHandName != value)
                {
                    _offHandName = value;
                    OnPropertyChanged(nameof(OffHandName));
                }
            } 
        }

    }
}
