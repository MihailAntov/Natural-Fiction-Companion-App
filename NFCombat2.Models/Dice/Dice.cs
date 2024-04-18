using NFCombat2.Models.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Dice
{
    public class Dice : INotifyPropertyChanged
    {
        public Dice(int maxValue)
        {
            MaxValue = maxValue;
            random = new Random();
        }
        private int diceValue = 0;
        public int DiceValue
        {
            get { return diceValue; }
            set
            {
                if (diceValue != value)
                {
                    diceValue = value;
                    OnPropertyChanged(nameof(DiceValue));
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        private bool canReroll = false;
        public bool CanReroll
        {
            get { return canReroll; }
            set
            {
                if (canReroll != value)
                {
                    canReroll = value;
                    OnPropertyChanged(nameof(CanReroll));
                }
            }
        }

        private bool canFreeReroll = false;
        public bool CanFreeReroll
        {
            get { return canFreeReroll; }
            set
            {
                if (canFreeReroll != value)
                {
                    canFreeReroll = value;
                    OnPropertyChanged(nameof(CanFreeReroll));
                }
            }
        }

        public int MaxValue { get; set; }

        public string FileName
        {
            get { return $"dice{DiceValue}"; }
        }
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }
        private Random random;
        public Player.Player Player { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged; 
        public void Roll()
        {
            DiceValue = random.Next(1, MaxValue + 1);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
