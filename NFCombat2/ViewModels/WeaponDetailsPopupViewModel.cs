

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
        public Command AddWeaponToPlayerCommand { get; set; }
        private InventoryPageViewModel _parentViewModel;
        public Popup Self { get; set; }
        public bool IsRanged => Weapon.MaxRange > 0;
        public bool HasFlatDamage => Weapon.FlatDamage > 0;
        public bool HasDamageDice => Weapon.DamageDice > 0;
        
        public string ChangeWeaponButtonName { get; set; }
        public WeaponDetailsPopupViewModel(Weapon weapon, InventoryPageViewModel parent, string buttonName)
        {
            Weapon = weapon;
            _parentViewModel = parent;
            AddWeaponToPlayerCommand = new Command(async () => await AddWeaponToPlayer(Weapon.Hand));
            ChangeWeaponButtonName = buttonName;
        }

        public async Task AddWeaponToPlayer(Hand hand)
        {
            await Self.CloseAsync();
            await _parentViewModel.AddWeaponToPlayer(hand);
        }

        
    }
}
