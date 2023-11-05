using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Helpers
{
    public class Dice : INotifyPropertyChanged
    {
        public Dice(int maxValue, string fileName)
        {
            MaxValue = maxValue;
            FileName = fileName;
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
                }
            }
        }
        public int MaxValue { get; set; }

        private string fileName = null!;
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void Roll()
        {
            DiceValue = random.Next(1, MaxValue + 1);
            FileName = $"dice{DiceValue}";
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
