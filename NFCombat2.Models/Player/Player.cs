

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Programs;
using NFCombat2.Models.SpecOps;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Player
{
    public class Player : INotifyPropertyChanged
    {
        
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private int health = 30;

        public event PropertyChangedEventHandler PropertyChanged;


        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if(value > MaxHealth)
                {
                    value = MaxHealth;
                }

                if(value < 0)
                {
                    value = 0;
                }

                if(health != value)
                {
                    health = value;
                    HealthHasChanged = true;
                    OnPropertyChanged(nameof(Health));
                }
            }
        }

        public bool HealthHasChanged { get; set; } = false;
        public int BaseMaxHealth { get; set; } = 30;
        public int MaxHealth
        {
            get
            {
                return BaseMaxHealth + Equipment.Where(e=> e is IModifyPlayer).Select(e=> (e as IModifyPlayer).BonusHealth).Sum();
            }
            
        }

        public bool HasExtraBag => Equipment.Where(e=> e is IModifyPlayer && (e as IModifyPlayer).HasBonusBag).Any();
        public int InventorySlots => HasExtraBag ? 13 : 10;
        public int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public int MaxWeaponWeight { get; set; } = 1;
        public List<Weapon> Weapons
        {
            get
            {
                var weapons = new List<Weapon>();
                if(MainHand != null)
                {
                    weapons.Add(MainHand);
                }
                if (OffHand != null)
                {
                    weapons.Add(OffHand);
                }
                return weapons;
            }
        }
        public Weapon MainHand { get; set; }
        public Weapon OffHand { get; set; }
        public IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        public IList<ICombatActiveItem> Consumables { get; set; } = new List<ICombatActiveItem>();
        public IList<Item> Items { get; set; } = new List<Item>();

        public IList<Technique> Techniques { get; set; } = new List<Technique>();
        public IList<Program> Programs { get; set; } = new List<Program>();
        public virtual IList<IModifyAction> ActionModifiers => Equipment.OfType<IModifyAction>().ToList();
        public virtual IList<IModifyResolution> ResolutionModifiers => Equipment.OfType<IModifyResolution>().ToList();
        public PlayerClass Class { get; set; } = PlayerClass.None;
        public IList<Part> Parts { get; set; } = new List<Part>();
        public int Trauma { get; set; } = 0;
        public int MaxTrauma { get; set; } = 3;
        public int Ionization { get; set; } = 0;
        public int MaxIonization { get; set; } = 3;
        public int Pathogens { get; set; } = 0;
        public int MaxPathogens { get; set; } = 3;
        private int speed = 3;
        public int Speed
        {
            get { return speed; }
            set
            {
                if(speed != value)
                {
                    speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }
        private int _overload;
        public int Overload
        {
            get { return _overload; }
            set
            {
                if(_overload != value)
                {
                    _overload = value;
                    OnPropertyChanged(nameof(Overload));
                }
            }
        }
        public Language Language { get; set; } = Language.English;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
