using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Common.Helpers
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Roll()
        {
            DiceValue = random.Next(1, MaxValue + 1);
           
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
