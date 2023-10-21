

using NFCombat2.Common.Enums;
using NFCombat2.Data.Models.Items;

namespace NFCombat2.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public PlayerClass PlayerClass { get; set; } = PlayerClass.None;
        public string Name { get; set; } = string.Empty;
        public int ClassId { get; set; } = 0;
        public int Trauma { get; set; } = 0;
        public int MaxTrauma { get; set; } = 3;
        public int Ionization { get; set; } = 0;
        public int MaxIonization { get; set; } = 3;
        public int Pathogens { get; set; } = 0;
        public int MaxPathogens { get; set; } = 3;
        public int Speed { get; set; } = 0;

        public int Strength { get; set; } = 0;
        public int Health { get; set; } = 30;
        public int MaxHealth { get; set; } = 30;
        public int Overload { get; set; } = 0;
        public int MaxOverload { get; set; } = 10;

        public int MaxWeaponWeight { get; set; } = 1;
        public ICollection<Weapon> Weapons { get; set; } = new HashSet<Weapon>();
        public ICollection<Modification> Modifications { get; set; } = new HashSet<Modification>();
        public ICollection<Modification> MainHandModifications { get; set; } = new HashSet<Modification>();
        public ICollection<Modification> OffHandModifications { get; set; } = new HashSet<Modification>();

        public ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
        public ICollection<Consumable> Consumables { get; set; } = new HashSet<Consumable>();
        public ICollection<Invention> Inventions { get; set; } = new HashSet<Invention>();

    }
}
