

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Player
{
    public class Soldier : Player
    {
        public Soldier()
        {
            BaseMaxHealth = 50;
            Health = 50;
            MaxIonization = 4;
            MaxPathogens = 4;
            MaxTrauma = 4;
            MaxWeaponWeight = 2;
            Class = PlayerClass.Soldier;
        }
    }
}
