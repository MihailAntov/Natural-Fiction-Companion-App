

using CommunityToolkit.Maui.Alerts;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class PartsBagViewModel : INotifyPropertyChanged
    {
        private PartBag _partBag;
        private readonly InventoryPageViewModel _inventoryPageViewModel;
        private readonly IPlayerService _playerService;
        private readonly INameService _nameService;
        private readonly IPopupService _popupService;
        private readonly IItemService _itemService;

        public PartsBagViewModel(
            IPlayerService playerService, 
            INameService nameService, 
            IPopupService popupService, 
            IItemService itemService,
            InventoryPageViewModel inventoryPageViewModel)
        {
            PartsBag = playerService.CurrentPlayer.PartsBag;
            _playerService = playerService;
            _nameService = nameService;
            _itemService = itemService;
            _inventoryPageViewModel = inventoryPageViewModel;
            CraftButtonText = _nameService.Label(Common.Enums.LabelType.CraftButton);
            CraftingPopupCommand = new Command(DisplayCraftingPopup);
            ExpandTabCommand = new Command<PartCategory>(ExpandTab);
            playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            _popupService = popupService;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command ExpandTabCommand { get; set; }
        public Command CraftingPopupCommand { get; set; }
        public async void DisplayCraftingPopup()
        {

            TaskCompletionSource<CraftResult> taskCompletionSource = new TaskCompletionSource<CraftResult>();
            var viewModel = new CraftingPopupViewModel(_playerService, _itemService,_nameService,_popupService, taskCompletionSource, _inventoryPageViewModel);
            var popup = new CraftingPopupView(viewModel);
            _popupService.ShowPopup(popup);
            var result = await taskCompletionSource.Task;
            
            if(result  == CraftResult.Cancelled)
            {
                return;
            }

            var toast = new Toast() { Text = _nameService.CraftResultMessage(result, viewModel.ToBeAdded) };
            await toast.Show();
            if(result == CraftResult.Correct)
            {
                await popup.CloseAsync();
            }
        }

        
        public string CraftButtonText { get; set; }
        public PartBag PartsBag { get { return _partBag; } 
            set 
            {
                if(_partBag != value)
                {
                    _partBag = value;
                    OnPropertyChanged(nameof(PartsBag));
                }
            } 
        }
        public void ExpandTab(PartCategory partCategory)
        {
            foreach (var pc in _partBag.Categories)
            {
                if(pc ==  partCategory)
                {
                    pc.IsExpanded = !pc.IsExpanded;
                    continue;
                }
                pc.IsExpanded = false;
            }
            //partCategory.IsExpanded = !partCategory.IsExpanded;
        }


        

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                PartsBag = _playerService.CurrentPlayer.PartsBag;
            }


        }
    }
}
