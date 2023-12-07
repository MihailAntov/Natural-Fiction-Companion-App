using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Items.Weapons
{
    public class Weapon : IAddable, INotifyPropertyChanged
    {
        public Accuracy Accuracy { get; set; }
        public int Id { get; set; }
        public int BonusAccuracy {get; set;}
        public Accuracy EffectiveAccuracy => Accuracy + BonusAccuracy;
        //public string Label { get; set; }
        public int MaxRange { get; set; }
        public int EffectiveMaxRange => MaxRange + BonusMaxRange;
        public int BonusMaxRange { get; set; }
        public int MinRange { get; set; }
        public bool AreaOfEffect { get; set; } = false;
        public int CritMultiplier { get; set; } = 2;
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Weight { get; set; }
        public int RemainingCooldown { get; set; } = 0;
        public int CooldownPerShot { get; set; } = 1;
        public int ShotsPerTurn { get; set; } = 1;
        public ICollection<WeaponModification> Modifications { get; set; } = new HashSet<WeaponModification>();

        public string Name { get; set; }
        public bool IsInvention { get; set; } = false;
        public Hand Hand { get; set; }
        public ItemType ItemType { get; set; }
        public bool AlwaysHits { get; set; } = false;

        public int Durability { get; set; } = 100;
        public int Quantity { get; set; } = 1;
        public string Image { get; set; } = string.Empty;
        private bool _hasGasOperatedReloadingSystem;
        public bool HasGasOperatedReloadingSystem {
            get { return _hasGasOperatedReloadingSystem; }
            set
            {
                if(_hasGasOperatedReloadingSystem != value)
                {
                    _hasGasOperatedReloadingSystem = value;
                    OnPropertyChanged(nameof(HasGasOperatedReloadingSystem));
                }
            }
        }
        private bool _hasBarrelExtender;
        public bool HasBarrelExtender
        {
            get { return _hasBarrelExtender; }
            set
            {
                if (_hasBarrelExtender != value)
                {
                    _hasBarrelExtender = value;
                    OnPropertyChanged(nameof(HasBarrelExtender));
                }
            }
        }
        private bool _hasLaserSight;
        public bool HasLaserSight
        {
            get { return _hasLaserSight; }
            set
            {
                if (_hasLaserSight != value)
                {
                    _hasLaserSight = value;
                    OnPropertyChanged(nameof(HasLaserSight));
                }
            }
        }
        private bool _hasGrenadeLauncher;
        public bool HasGrenadeLauncher
        {
            get { return _hasGrenadeLauncher; }
            set
            {
                if (_hasGrenadeLauncher != value)
                {
                    _hasGrenadeLauncher = value;
                    OnPropertyChanged(nameof(HasGrenadeLauncher));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
