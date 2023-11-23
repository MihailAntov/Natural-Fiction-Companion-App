

using NFCombat2.Contracts;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Player;
using NFCombat2.Models.Items;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NFCombat2.Models.Contracts;

namespace NFCombat2.ViewModels
{
    public class EntryWithSuggestionsViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;

        public event PropertyChangedEventHandler PropertyChanged;
        private TaskCompletionSource<IAddable> _taskCompletionSource;
        public EntryWithSuggestionsViewModel(
            IPlayerService playerService,
            ICollection<IAddable> allOptions,
            TaskCompletionSource<IAddable> taskCompletionSource
            )
        {
            _allOptions = allOptions;
            _playerService = playerService;
            _taskCompletionSource = taskCompletionSource;

        }
        private ICollection<IAddable> _allOptions = new List<IAddable>();
        public ObservableCollection<IAddable> Options { get; set; } = new ObservableCollection<IAddable>();

        private bool _areSuggestionsVisible = false;
        
        public bool AreSuggestionsVisible
        {
            get { return _areSuggestionsVisible; }
            set
            {
                if (_areSuggestionsVisible != value)
                {
                    _areSuggestionsVisible = value;
                    OnPropertyChanged(nameof(AreSuggestionsVisible));
                }
            }
        }

        public string SearchCriteria { get; set; }

        

        public async Task ChooseOption(object option)
        {
            if(option is IAddable entry)
            {
                await _playerService.AddItemToPlayer(entry);
                _taskCompletionSource.SetResult(entry);
            }
            AreSuggestionsVisible = false;
            SearchCriteria = string.Empty;
            
        }

        public void EnteredText(object i)
        {
            if (i is Entry entry)
            {
                var filtered = _allOptions.Where(i => i.Name.ToLower().Contains(entry.Text.ToLower())).ToList();
                Options.Clear();
                foreach (var item in filtered)
                {
                    Options.Add(item);
                }


                if (entry.Text.Length > 2)
                {
                    AreSuggestionsVisible = true;
                    //OnPropertyChanged(nameof(Options));
                }
                else
                {
                    AreSuggestionsVisible = false;
                    //OnPropertyChanged(nameof(Options));
                }
            }
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        
    }
}
