

using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Parts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CraftingPopupViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IItemService _itemService;
        private readonly INameService _nameService;
        private readonly IPopupService _popupService;
        private TaskCompletionSource<CraftResult> _taskCompletionSource;   
        public CraftingPopupViewModel(IPlayerService playerService, IItemService itemService, TaskCompletionSource<CraftResult> taskCompletionSource)
        {
            _playerService = playerService;
            SetUpParts();
            CraftCommand = new Command(Craft);
            ConfirmEpisodeCommand = new Command(ConfirmEpisode);
            _taskCompletionSource = taskCompletionSource;
            _itemService = itemService;
        }

        public string Episode { get; set; }
        public IAddable ToBeAdded { get; set; } = null;
        public Command CraftCommand { get; set; }
        public Command ConfirmEpisodeCommand { get; set; }

        public List<Part> Parts { get; set; }
        private bool _correctFormula = false;
        public bool CorrectFormula { get { return _correctFormula; } set
            {
                if(_correctFormula != value)
                {
                    _correctFormula = value;
                    OnPropertyChanged(nameof(CorrectFormula));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void Craft()
        {
            string result = string.Join(string.Empty,Parts
                .Select(p => new string(char.Parse(p.WorkCoefficient.ToString()),p.CurrentlySelected))
                .OrderBy(s=>s));
            if(result.Length == 0 )
            {
                _taskCompletionSource.TrySetResult(CraftResult.Incorrect);
                return;
            }

            ToBeAdded = _itemService.CheckFormula(result);
            if(ToBeAdded == null)
            {
                _taskCompletionSource.TrySetResult(CraftResult.Incorrect);
                return;
            }
            
            CorrectFormula = true;
            return;

        }

        public async void ConfirmEpisode()
        {
            if(ToBeAdded.Episode == int.Parse(Episode))
            {
                _taskCompletionSource.TrySetResult(CraftResult.Correct);
                await _playerService.AddItemToPlayer(ToBeAdded);
                foreach(var part in Parts)
                {
                    part.Quantity -= part.CurrentlySelected;
                }
                return;
            }

            _taskCompletionSource.TrySetResult(CraftResult.Incorrect);

        }


        private void SetUpParts()
        {
            var bag = _playerService.CurrentPlayer.PartsBag;
            Parts = bag.Categories.SelectMany(c=> c.Parts).Where(p=> p.Quantity > 0).ToList();
        }

        public void Cancel()
        {
            CorrectFormula = false;
            _taskCompletionSource.TrySetResult(CraftResult.Cancelled);
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
