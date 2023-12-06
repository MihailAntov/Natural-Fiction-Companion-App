

using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Items.Weapons;
using System.ComponentModel;

namespace NFCombat2.ViewModels
{
    public class WeaponDetailsPopupViewModel 
    {
        public Weapon Weapon { get; set; }
        public Hand Hand { get; set; }
        public Command AddWeaponToPlayerCommand { get; set; }
        private InventoryPageViewModel _parentViewModel;
        public Popup Self { get; set; }
        public bool IsRanged { get; set; } = true;
        public bool HasFlatDamage { get; set; } = true;
        public bool HasDamageDice { get; set; } = true;
        public bool HasWeapon { get; set; } = true;
        private readonly INameService _nameService;
        public string ChangeWeaponButtonName { get; set; }
        public WeaponDetailsPopupViewModel(Weapon weapon, InventoryPageViewModel parent, INameService nameService, Hand hand)
        {
            Weapon = weapon;
            Hand = hand;
            _parentViewModel = parent;
            AddWeaponToPlayerCommand = new Command(async () => await AddWeaponToPlayer(Hand));
            _nameService = nameService;
            
            if(weapon == null)
            {
                HasWeapon = false;
                ChangeWeaponButtonName = _nameService.Label(LabelType.EquipNewWeaponButton);
            }
            else
            {
                ChangeWeaponButtonName = _nameService.Label(LabelType.ChangeWeaponButton);
                IsRanged = Weapon.MaxRange > 0;
                HasDamageDice = Weapon.DamageDice > 0;
                HasFlatDamage = Weapon.FlatDamage > 0;
            }
        }

        public async Task AddWeaponToPlayer(Hand hand)
        {
            await Self.CloseAsync();
            await _parentViewModel.AddWeaponToPlayer(hand);
        }

        
    }
}
