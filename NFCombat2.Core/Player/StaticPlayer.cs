

using NFCombat2.Models.Items;
using NFCombat2.Models.Programs;

namespace NFCombat2.Models.Player
{
    public static class StaticPlayer 
    {
        public static int Health { get; set; }
        public static int MaxHealth { get; set; }
        public static int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public static int MaxWeaponWeight { get; set; } = 1;
        public static IList<Weapon> Weapons { get; set; } = new List<Weapon>();
        public static IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        public static IList<Consumable> Consumables { get; set; } = new List<Consumable>();
        public static IList<Program> Programs { get; set; } = new List<Program>();
        public static IList<Skill> SpecialMoves { get; set; } = new List<Skill>();
        public static int Trauma { get; set; }
        public static int MaxTrauma { get; set; }
        public static int Ionization { get; set; }
        public static int MaxIonization { get; set; }
        public static int Pathogens { get; set; }
        public static int MaxPathogens { get; set; }
        public static int Speed { get; set; }
    }
}
