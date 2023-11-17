

using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class Bundle : Equipment, IModifyPlayer
    {
        public Bundle()
        {
            Name = "Bundle";
            BonusHealth = 0;
            HasBonusBag = true;
        }
        public int BonusHealth { get; set;}
        public bool HasBonusBag { get; set; }
    }
}
