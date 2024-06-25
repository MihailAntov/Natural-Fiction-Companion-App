

using CommunityToolkit.Maui.Views;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class MultipleChoicePopupViewModel : INotifyPropertyChanged
    {
        public ICollection<IOption> Options { get; set; }
        private Fight _fight;
        public Command ChooseCommand { get; set; }
        private TaskCompletionSource<IOption> _taskCompletionSource;
        public Popup Popup { get; set; }
        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string Title { get { return _title; } set 
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public MultipleChoicePopupViewModel(IOptionList options, Fight fight, TaskCompletionSource<IOption> taskCompletionSource)
        {
            Options = options.Options;
            Title = options.Label;
            _fight = fight;
            _taskCompletionSource = taskCompletionSource;
            ChooseCommand = new Command<IOption>(Choose);
        }

        public void Choose(IOption option)
        {

            _taskCompletionSource.SetResult(option);
            Popup.CloseAsync();
        }


    }
}
