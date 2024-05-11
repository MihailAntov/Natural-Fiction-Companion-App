

using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class CraftingPopupViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IItemService _itemService;
        private readonly InventoryPageViewModel _inventoryPageViewModel;
        private readonly IPopupService _popupService;
        private TaskCompletionSource<CraftResult> _taskCompletionSource;   
        public CraftingPopupViewModel(IPlayerService playerService, IItemService itemService, INameService nameService,IPopupService popupService, TaskCompletionSource<CraftResult> taskCompletionSource, InventoryPageViewModel inventoryPageViewModel) : base(nameService)
        {
            _playerService = playerService;
            SetUpParts();
            CraftCommand = new Command(Craft);
            ConfirmEpisodeCommand = new Command(ConfirmEpisode);
            _taskCompletionSource = taskCompletionSource;
            _itemService = itemService;
            _nameService = nameService;
            _popupService = popupService;
            _inventoryPageViewModel = inventoryPageViewModel;
            _playerService.SavePlayer();
        }

        public override void UpdateLanguageSpecificProperties()
        {
            CraftButtonLabel = _nameService.Label(LabelType.CraftButton);
            ConfirmButtonLabel = _nameService.Label(LabelType.ConfirmButton);
        }
        public string Episode { get; set; }
        public IAddable ToBeAdded { get; set; } = null;
        public Command CraftCommand { get; set; }
        public Command ConfirmEpisodeCommand { get; set; }

        public List<Part> Parts { get; set; }

        private string _craftButtonLabel;
        public string CraftButtonLabel { get { return _craftButtonLabel; } set
            {
                if(_craftButtonLabel != value)
                {
                    _craftButtonLabel = value;
                    OnPropertyChanged(nameof(CraftButtonLabel));
                }
            } 
        }
        private string _confirmButtonLabel;
        public string ConfirmButtonLabel { get { return _confirmButtonLabel; } set
            {
                if(_confirmButtonLabel != value)
                {
                    _confirmButtonLabel = value;
                    OnPropertyChanged(nameof(ConfirmButtonLabel));
                }
            } 
        }
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
                .OrderBy(s=>s)).ToLower();
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
                //magic needs to happen here
                if (ToBeAdded is Weapon weapon)
                {
                    var hand = await _popupService.ShowHandChoicePopup(_nameService);
                    weapon.Hand = hand;
                }
                
                await _playerService.AddItemToPlayer(ToBeAdded);
                foreach(var part in Parts.Where(p=>p.CurrentlySelected > 0))
                {
                    int cost = part.CurrentlySelected;
                    part.CurrentlySelected = 0;
                    part.Quantity -= cost;
                }
                _inventoryPageViewModel.UpdateWeaponDisplay();
                return;
            }

            _taskCompletionSource.TrySetResult(CraftResult.Incorrect);

        }


        private void SetUpParts()
        {
            var bag = _playerService.CurrentPlayer.PartsBag;
            Parts = bag.Categories.SelectMany(c=> c.Parts).Where(p=> p.Quantity > 0).ToList();
            foreach(var part in Parts)
            {
                part.DisplayMaximum = part.Quantity;
            }
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
