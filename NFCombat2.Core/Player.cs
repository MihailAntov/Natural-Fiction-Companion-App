namespace NFCombat2.Models
{
    public abstract class Player
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public int MaxWeaponWeight { get; set; } = 1;
        public IList<Weapon> Weapons { get; set; } = new List<Weapon>();
        public IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        public IList<Consumable> Consumables { get; set; } = new List<Consumable>();
        public IList<Program> Programs { get; set; } = new List<Program>();
        public IList<Skill> SpecialMoves { get; set; } = new List<Skill>();
        public int Trauma { get; set; }
        public int MaxTrauma { get; set; }
        public int Ionization { get; set; }
        public int MaxIonization { get; set; }
        public int Pathogens { get; set; }
        public int MaxPathogens { get; set; }
        public int Speed { get; set; }
    }
}
