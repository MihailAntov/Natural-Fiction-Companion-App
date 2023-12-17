using NFCombat2.Common.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Fights
{
    public class Enemy : INotifyPropertyChanged
    {
        public bool Damageable { get; set; } = true;
        private int range;
        public string Name { get; set; }
        private int health;
        public int Health { get { return health; } 
            set
            {
                if(value < 0)
                {
                    value = 0;
                }

                if(health != value)
                {
                    health = value;
                     
                    OnPropertyChanged("Health");
                }
            }
        }
        public int Strength { get { return (int)Math.Round(Health / 10.0) + BonusStrength; } }
        public Accuracy Accuracy { get; set; }
        public bool HasMoved { get; set; } = false;
        public int BonusStrength { get; set; }
        public int Range
        {
            get { return range; }
            set
            {
                range = value;
                OnPropertyChanged();
            }
        }
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        private int distance;
        public int Distance
        {
            get { return distance; }    
            set
            {
                if(value < 0)
                {
                    value = 0;
                }

                if(distance != value)
                {
                    distance = value;
                    OnPropertyChanged(nameof(Distance));
                }
            }
        }
        public int Speed { get; set; } = 3;
        public int RemainingFrozenTurns { get; set; } = 0;
        public bool AlwaysHits { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
