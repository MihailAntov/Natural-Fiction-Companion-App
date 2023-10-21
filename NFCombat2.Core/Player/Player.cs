

namespace NFCombat2.Models.Player
{
    public class Player
    {
        public string Name { get; set; } = null!;
        public int Health { get; set; } = 30;
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
        public int Speed { get; set; } = 0;
    }
}
