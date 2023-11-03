

using NFCombat2.Common.Enums;
using NFCombat2.Models.Items;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Player
{
    public class Player : INotifyPropertyChanged
    {
        

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

                if(value != health)
                {
                    value = health;
                    OnPropertyChanged(nameof(Health));
                }
            }
        }
        public int MaxHealth { get; set; } = 30;
        public int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public int MaxWeaponWeight { get; set; } = 1;
        public IList<Weapon> Weapons { get; set; } = new List<Weapon>();
        public IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        public IList<Consumable> Consumables { get; set; } = new List<Consumable>();

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
        public Language Language { get; set; } = Language.English;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
