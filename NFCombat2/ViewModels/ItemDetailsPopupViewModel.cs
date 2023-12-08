

using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.ViewModels
{
    public class ItemDetailsPopupViewModel
    {
        private readonly INameService _nameService;
        private readonly InventoryPageViewModel _parentViewModel;
        public Command UseItemCommand { get; set; }
        public IAddable Item { get; set; }
        public string UseItemButtonName { get; set; }
        public Popup Self { get; set; }
        public ItemDetailsPopupViewModel(
            IAddable item,
            InventoryPageViewModel parentViewModel,
            INameService nameService)
        {
            Item = item;
            _parentViewModel = parentViewModel;
            _nameService = nameService;
            UseItemButtonName = _nameService.Label(LabelType.UseItemButton);
            UseItemCommand = new Command(async () => await UseItem());
        }


        public async Task UseItem()
        {
            await Self.CloseAsync();
            if(Item is Equipment equipment)
            {
                _parentViewModel.UsedEquipment(equipment);
                return;
            }

            _parentViewModel.UsedItem(Item);
        }

    }
}
