﻿using NFCombat2.Common.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Fights
{
    public class Enemy : INotifyPropertyChanged
    {
        private int range;
        public string Name { get; set; }
        private int health;
        public int Health { get { return health; } 
            set
            {
                if(health != value)
                {
                    health = value;
                    OnPropertyChanged("Health");
                }
            }
        }
        public int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public Accuracy Accuracy { get; set; }
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
        public int Speed { get; set; }
        public int RemainingFrozenTurns { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
