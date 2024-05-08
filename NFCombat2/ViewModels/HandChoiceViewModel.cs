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
    public class HandChoiceViewModel : INotifyPropertyChanged
    {
        private readonly TaskCompletionSource<Hand> _taskCompletionSource;
        private readonly INameService _nameService;
        public HandChoiceViewModel(TaskCompletionSource<Hand> taskCompletionSource, INameService nameService)
        {
            _taskCompletionSource = taskCompletionSource;
            _nameService = nameService;
            MainHandName = _nameService.HandName(Hand.MainHand);
            OffHandName = _nameService.HandName(Hand.OffHand);
            ChooseHandCommand = new Command<string>(async (s)=> await ChooseHand(s));
        }
        private string _mainHandName;
        public Popup Popup { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    }
}
