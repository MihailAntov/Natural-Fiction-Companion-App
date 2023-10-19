

namespace NFCombat2.Models.Player
{
    public abstract class Player
    {
        public static int Health { get; set; } = 30;
        public static int MaxHealth { get; set; } = 30;
        public static int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public static int MaxWeaponWeight { get; set; } = 1;
        public static IList<Weapon> Weapons { get; set; } = new List<Weapon>();
        public static IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        public static IList<Consumable> Consumables { get; set; } = new List<Consumable>();
        public static int Trauma { get; set; } = 0;
        public static int MaxTrauma { get; set; } = 3;
        public static int Ionization { get; set; } = 0;
        public static int MaxIonization { get; set; } = 3;
        public static int Pathogens { get; set; } = 0;
        public static int MaxPathogens { get; set; } = 3;
        public static int Speed { get; set; } = 0;
    }
}
